using Application.Dtos.CustomQuestionDtos;

using AutoMapper;
using Domain.Entities;
using Domain.EnumExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class CustomQuestionMapper : Profile
    {
            public CustomQuestionMapper()
            {
                CreateMap<CreateCustomQuestionDto, CustomQuestion>()
                .ForMember(dest => dest.Type, m => m.MapFrom(src => src.Type.GetDescription()));

                CreateMap<CustomQuestion, CustomQuestionDto>();
               
            }
        
    }
}
