using MassTransit;
using PaymentService.DTOs.Test;
using Rekeningrijden.RabbitMq;

namespace PaymentService.Services.Test
{
    public interface ITestService
    {
        public Task<List<GetTestDTO>> getAllTests();

        public Task<string> rabbitMqTest(TestRabbitMqClass rabbit);
    }
}
