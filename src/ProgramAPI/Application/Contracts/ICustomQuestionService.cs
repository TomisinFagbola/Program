using Application.Dtos.CustomQuestionDtos;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;
public interface ICustomQuestionService
{
    Task<SuccessResponse<CustomQuestionDto>> Create(CreateCustomQuestionDto createCustomQuestionDto);

    Task<SuccessResponse<CustomQuestionDto>> Get(string customQuestionId);
}
