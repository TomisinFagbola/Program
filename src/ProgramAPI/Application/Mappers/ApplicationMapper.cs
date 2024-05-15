using Application.Dtos.AdditionalQuestionDtos;
using Application.Dtos.ApplicationDtos;
using Application.Dtos.PersonalInformation;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ApplicationMapper : Profile
    {
   
        public ApplicationMapper()
        {
            CreateMap<CreateApplicationDto, ProgramApplication>();
            CreateMap<PersonalInformationDto, PersonalInformation>().ReverseMap();
            CreateMap<AdditionalQuestionDto, AdditionalQuestion>().ReverseMap();
            CreateMap<ProgramApplication, ApplicationDto>();
            

        }
    }
}
