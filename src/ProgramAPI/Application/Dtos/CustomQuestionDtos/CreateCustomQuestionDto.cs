using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.CustomQuestionDtos;
public record CreateCustomQuestionDto : BaseCustomQuestionDto
{
    public string Title { get; set; }
    public EQuestionType Type { get; set; }
}
