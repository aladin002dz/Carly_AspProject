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
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Manufacturer, ManufacturerDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<NewRentalDto, Rental>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CarDto, Car>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}