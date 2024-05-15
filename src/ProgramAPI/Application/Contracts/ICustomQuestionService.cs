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
    /// <summary>
    /// Create Custom Question
    /// </summary>
    /// <param name="createCustomQuestionDto"></param>
    /// <returns>CustomQuestDto</returns>
    Task<SuccessResponse<CustomQuestionDto>> Create(CreateCustomQuestionDto createCustomQuestionDto);

    /// <summary>
    /// Get Custom Question by Type
    /// </summary>
    /// <param name="customQuestionType"></param>
    /// <returns>CustomQuestDto</returns>
    Task<SuccessResponse<CustomQuestionDto>> Get(string customQuestionType);
}
