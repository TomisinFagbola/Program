using API.Controllers;
using Application.Contracts;
using Application.Dtos.ApplicationDtos;
using Application.Dtos.CustomQuestionDtos;
using Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks.Application;
using Tests.Mocks.CustomQuestion;
using Xunit;

namespace Tests.UnitTests.CustomQuestion;
public class CustomQuestionTest
{
    private Mock<IServiceManager> _mock;
    public CustomQuestionTest()
    {
        _mock = new Mock<IServiceManager>();
    }


    [Fact]
    public void CanDoUnitTests()
    {
        var setup = 1 + 1;

        Assert.Equal<int>(2, setup);
    }

    [Fact]
    public async Task CanCreateParagraphCustomQuestion()
    {
        // arrange
        var successResponseDTOMock = CustomQuestionMock.SuccessResponseDTOMock;
        _mock.Setup(p => p.CustomQuestion.Create(CustomQuestionMock.ParagraphCustomDtoMock))
            .Returns(Task.FromResult(successResponseDTOMock));

        // act
        CustomQuestionController customQuestion = new CustomQuestionController(_mock.Object);
        var createdAtActionResult = await customQuestion.Create(CustomQuestionMock.ParagraphCustomDtoMock) as CreatedAtActionResult;
        var result = (SuccessResponse<CustomQuestionDto>)createdAtActionResult.Value;

        // assert
        Assert.IsType<SuccessResponse<CustomQuestionDto>>(createdAtActionResult.Value);
        Assert.Equal(successResponseDTOMock.Data?.Title, result?.Data?.Title);
        Assert.Equal(successResponseDTOMock.Data?.Type, result?.Data?.Type);
    }

    [Fact]
    public async Task CanCreateMultipleCustomQuestion()
    {
        // arrange
        var multipleSuccessResponseDTOMock = CustomQuestionMock.MultipleChoiceSuccessResponseDTOMock;
        _mock.Setup(p => p.CustomQuestion.Create(CustomQuestionMock.MultpleChoiceCustomDtoMock))
            .Returns(Task.FromResult(multipleSuccessResponseDTOMock));

        // act
        CustomQuestionController customQuestion = new CustomQuestionController(_mock.Object);
        var createdAtActionResult = await customQuestion.Create(CustomQuestionMock.MultpleChoiceCustomDtoMock) as CreatedAtActionResult;
        var result = (SuccessResponse<CustomQuestionDto>)createdAtActionResult.Value;

        // assert
        Assert.IsType<SuccessResponse<CustomQuestionDto>>(createdAtActionResult.Value);
        Assert.Equal(multipleSuccessResponseDTOMock.Data?.Title, result?.Data?.Title);
        Assert.Equal(multipleSuccessResponseDTOMock.Data?.Type, result?.Data?.Type);
    }
}