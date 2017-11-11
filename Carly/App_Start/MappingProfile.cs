using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Carly.Models;
using Carly.Dtos;

namespace Carly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<CarDto, Car>();
        }
    }
}