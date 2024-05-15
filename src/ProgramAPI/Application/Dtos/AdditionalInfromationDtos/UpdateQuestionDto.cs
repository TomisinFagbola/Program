using Application.Dtos.CustomQuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AdditionalQuestionDtos;
    public record UpdateQuestionDto : BaseCustomQuestionDto
    {
        public Guid QuestionId { get; set; }
    }

