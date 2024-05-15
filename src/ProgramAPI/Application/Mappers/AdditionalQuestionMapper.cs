using Application.Dtos.AdditionalQuestionDtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AdditionalQuestionMapper : Profile
    {
        public AdditionalQuestionMapper()
        {
            CreateMap<AdditionalQuestionDto, AdditionalQuestion>();


        }
    }
}
