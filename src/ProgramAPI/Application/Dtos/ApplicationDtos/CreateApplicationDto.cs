using Application.Dtos.AdditionalQuestionDtos;
using Application.Dtos.PersonalInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ApplicationDtos;
public record CreateApplicationDto
    {
        public PersonalInformationDto PersonalInformation { get; set; }
        public List<AdditionalQuestionDto> AdditionalQuestions { get; set; }
    }

