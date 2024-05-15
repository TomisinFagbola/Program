using Application.Dtos.CustomQuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AdditionalQuestionDtos;
    public record AdditionalQuestionDto : BaseCustomQuestionDto
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

