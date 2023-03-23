using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentService.DTOs.Test;
using PaymentService.Services.Test;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ITestService _testService;

        public PaymentController(ITestService testService)
        {
            _testService = testService;

            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672, UserName = "myuser", Password = "mypassword" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare("test", ExchangeType.Topic, true);

            channel.QueueDeclare(queue: "hello",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.QueueBind("hello", ExchangeType.Topic, "demo");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += received;
            channel.BasicConsume("hello", true, consumer);
            

        }

        private static void received(object? sender, BasicDeliverEventArgs e)
        {   
            byte[] body = e.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            
        }





        [HttpGet]
        public async Task<string> Test()
        {
            return "payment controller 1";
        }

        [HttpGet("/test")]
        public async Task<ActionResult<List<GetTestDTO>>> Value()
        {
            try
            {
                List<GetTestDTO> response = await _testService.getAllTests();
                if(response == null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(null);
            }
        }

        //[HttpGet("/prices")]
        //public async Task<ActionResult<List<>>> getPrices()
        //{


        //}





    }
}
