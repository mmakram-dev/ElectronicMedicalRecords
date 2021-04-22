using AutoMapper;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DoctorModel, Doctor>();
            CreateMap<Doctor, DoctorModel>();

            //Registration Model Mapping
            CreateMap<User, RegisterRequestModel>();
            CreateMap<RegisterRequestModel, User>();

            //UserDetails Model Mapping
            CreateMap<User, GetUserDetailsResponseModelResult>();
            CreateMap<GetUserDetailsResponseModelResult, User>();


        }
    }
}
