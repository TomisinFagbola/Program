using Application.Contracts;
using Application.Dtos.ApplicationDtos;
using Application.Dtos.PersonalInformation;
using Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/applications")]
    public class ApplicationController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;


    /// <summary>
    /// Endpoint to create an application
    /// </summary>
    /// <param name="createApplicationDto"></param>
    /// <returns></returns>
    //[Authorize(Roles = "AllowAnonymous")]
    [HttpPost("create")]
        [ProducesResponseType(typeof(SuccessResponse<ApplicationDto>), 201)]
        public async Task<IActionResult> Create([FromBody] CreateApplicationDto createApplicationDto)
        {
            var response = await _service.Application.Create(createApplicationDto);
               return CreatedAtAction(nameof(Create), response);
    }

    /// <summary>
    /// Endpoint to update question in an application 
    /// </summary>
    /// <param name="updateApplicationDto"></param> 
    /// <returns></returns>
    /// [Authorize(Roles = "AllowAnonymous")]
    [HttpPut("update-question")]
        [ProducesResponseType(typeof(SuccessResponse<ApplicationDto>), 200)]
        public async Task<IActionResult> UpdateQuestion([FromQuery] string id, UpdateApplicationDto updateApplicationDto)
        {
            var response = await _service.Application.Update(updateApplicationDto, id);
            return Ok(response);
        }

    }

