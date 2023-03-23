using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using AutoMapper;
using PaymentService.Models;
using PaymentService.DTOs.Test;
using PaymentService.Services.Test;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(5, 7, 31)));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    //context.Database.Migrate();
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

IConnectionFactory factory = new ConnectionFactory { HostName = "localhost", Port = 5672, UserName = "myuser", Password = "mypassword" };
using (IConnection connection = factory.CreateConnection())
{
    IModel channel = connection.CreateModel();
    channel.ExchangeDeclare("test", ExchangeType.Topic, true);

    channel.QueueDeclare("hello", true, false,false, null);

    channel.QueueBind("hello", "test", "demo");

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += received;
    channel.BasicConsume("hello", true, consumer);
};


static void received(object? sender, BasicDeliverEventArgs e)
{
    byte[] body = e.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

}


app.Run();