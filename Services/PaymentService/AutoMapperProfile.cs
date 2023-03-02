using AutoMapper;
using PaymentService.DTOs.Test;
using PaymentService.Models;

namespace PaymentService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Test, GetTestDTO>();
        }
    }
}
