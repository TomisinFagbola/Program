using API.Controllers;
using Application.Contracts;
using Application.Dtos.ApplicationDtos;
using Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks.Application;
using Xunit;

namespace Tests.UnitTests.Application;
public class ApplicationTest
{
    private Mock<IServiceManager> _mock;
    public ApplicationTest()
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
    public async Task CanCreateApplication()
    {
        // arrange
        var successResponseDTOMock = ApplicationMock.SuccessResponseDTOMock;
        _mock.Setup(p => p.Application.Create(ApplicationMock.CreateApplicationDtoMock))
            .Returns(Task.FromResult(successResponseDTOMock));

        // act
        ApplicationController applicationController = new ApplicationController(_mock.Object);
        var createdAtActionResult = await applicationController.Create(ApplicationMock.CreateApplicationDtoMock) as CreatedAtActionResult;
        var result = (SuccessResponse<ApplicationDto>)createdAtActionResult.Value;

        // assert
        Assert.IsType<SuccessResponse<ApplicationDto>>(createdAtActionResult.Value);
        Assert.Equal(successResponseDTOMock.Data?.PersonalInformation.LastName, result?.Data?.PersonalInformation.LastName);
        Assert.Equal(successResponseDTOMock.Data?.PersonalInformation.FirstName, result?.Data?.PersonalInformation.FirstName);
    }

    [Fact]
    public async Task CanUpdateApplication()
    {

        // arrange
        string id = "14f1e884-4524-4da5-9ef9-8f1e749e6585";
        var updateSuccessResponseDTOMock = ApplicationMock.UpdateSuccessResponseDTOMock;
        _mock.Setup(p => p.Application.Update(ApplicationMock.UpdateApplicationDtoMock, id))
            .Returns(Task.FromResult(updateSuccessResponseDTOMock));

        // act
        ApplicationController applicationController = new ApplicationController(_mock.Object);
        var okResult = await applicationController.UpdateQuestion(id, ApplicationMock.UpdateApplicationDtoMock) as OkObjectResult;
        var result = (SuccessResponse<ApplicationDto>)okResult.Value;

        // assert
        Assert.IsType<SuccessResponse<ApplicationDto>>(okResult.Value);
        Assert.Equal(updateSuccessResponseDTOMock.Data?.PersonalInformation.LastName, result?.Data?.PersonalInformation.LastName);
        Assert.Equal(updateSuccessResponseDTOMock.Data?.PersonalInformation.FirstName, result?.Data?.PersonalInformation.FirstName);
    }
}


