using Application.Dtos.AdditionalQuestionDtos;
using Application.Dtos.PersonalInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ApplicationDtos;
    public record ApplicationDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }

        public List<AdditionalQuestionDto> AdditionalQuestions { get; set; }
    }
