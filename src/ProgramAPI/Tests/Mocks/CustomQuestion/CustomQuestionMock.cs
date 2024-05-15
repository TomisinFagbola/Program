using Application.Dtos.CustomQuestionDtos;
using Application.Helpers;
using Domain.EnumExtensions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks.CustomQuestion;
public record CustomQuestionMock
{
    public static CreateCustomQuestionDto ParagraphCustomDtoMock = new()
    {

        Title = "Please tell me about yourself in less than 500 words",
        Type = EQuestionType.Paragraph,
        isAnswered = false,
        Options = null,

    };

    public static CreateCustomQuestionDto MultpleChoiceCustomDtoMock = new()
    {

        Title = "Please select at least three answers from the drop down below",
        Type = EQuestionType.MultipleChoice,
        isAnswered = false,
        Options = new()
            {
                "Creative",
                "Outgoing",
                "Introverted"
            },

    };
    public static CreateCustomQuestionDto YesNoCustomDtoMock = new()
    {

        Title = "Have you ever been rejected by the UK Embassy",
        Type = EQuestionType.YesNo,
        isAnswered = false,
        Options = null

    };

    public static CustomQuestionDto ResponseParagraphMock = new()
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Please tell me about yourself in less than 500 words",
        Type = EQuestionType.Paragraph.GetDescription(),
        isAnswered = false,
        Options = null
    };


    public static CustomQuestionDto ResponseMultipleMock = new()
    {
        Id = Guid.NewGuid().ToString(),
        Title = "Please select at least three answers from the drop down below",
        Type = EQuestionType.MultipleChoice.GetDescription(),
        isAnswered = false,
        Options = new()
            {
                "Creative",
                "Outgoing",
                "Introverted"
            },
    };


    public static SuccessResponse<CustomQuestionDto> SuccessResponseDTOMock = new SuccessResponse<CustomQuestionDto>
    {
        Message = "Data created successfully created",
        Data = ResponseParagraphMock,
        Success = true
    };


    public static SuccessResponse<CustomQuestionDto> MultipleChoiceSuccessResponseDTOMock = new SuccessResponse<CustomQuestionDto>
    {
        Message = "Data created successfully created",
        Data = ResponseMultipleMock,
        Success = true
    };
}


