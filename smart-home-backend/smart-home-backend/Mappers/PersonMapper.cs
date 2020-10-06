using AutoMapper;
using smart_home_backend.Datasource.Models;
using smart_home_backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home_backend.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<PersonDto, PersonEntity>();
            CreateMap<PersonDto, PersonEntity>().ReverseMap();
        }
    }
}
