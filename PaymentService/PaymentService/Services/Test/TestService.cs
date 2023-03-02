using PaymentService.Data;
using PaymentService.DTOs.Test;
using PaymentService.Models;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaymentService.Services.Test
{
    public class TestService : ITestService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public TestService(DataContext context, IMapper mapper) 
        {
            _dataContext = context;
            _mapper = mapper;
        }

        public async Task<List<GetTestDTO>> getAllTests()
        {
            List<GetTestDTO> response = new List<GetTestDTO>();
                      
            try
            {
                List<Models.Test> tests = await _dataContext.Tests.ToListAsync();

                response = tests.Select(t => _mapper.Map<Models.Test, GetTestDTO>(t)).ToList();
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }






    }
}
