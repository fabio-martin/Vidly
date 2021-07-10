using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                    .CreateMap<Customer, CustomerDto>();
                cfg
                    .CreateMap<CustomerDto, Customer>()
                    .ForMember(
                    m => m.Id,
                    opt => opt.Ignore()); ;
                cfg
                    .CreateMap<Movie, MovieDto>();
                cfg
                    .CreateMap<MovieDto, Movie>()
                    .ForMember(
                        m => m.Id,
                        opt => opt.Ignore());

                cfg
                    .CreateMap<MembershipType, MembershipTypeDto>();
                cfg
                    .CreateMap<MembershipTypeDto, MembershipType>()
                    .ForMember(
                        m => m.Id,
                        opt => opt.Ignore());


            });

            Mapper = config.CreateMapper();
        }
    }
}