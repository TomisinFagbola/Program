using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.CustomQuestionDtos;
public record BaseCustomQuestionDto
{

    public List<string> Options { get; set; }
    public bool isAnswered { get; set; }
}


