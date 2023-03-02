using PaymentService.DTOs.Test;

namespace PaymentService.Services.Test
{
    public interface ITestService
    {
        public Task<List<GetTestDTO>> getAllTests();

    }
}
