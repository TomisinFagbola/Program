using Application.Contracts;
using Application.Dtos.CustomQuestionDtos;
using Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customquestions")]

    public class CustomQuestionController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CustomQuestionController(IServiceManager service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint to create a custom question
        /// </summary>
        /// <param name="createCustomQuestionDto"></param> 
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpPost()]
        [ProducesResponseType(typeof(SuccessResponse<CustomQuestionDto>), 201)]
        public async Task<IActionResult> Create([FromForm] CreateCustomQuestionDto createCustomQuestionDto)
        {
            var response = await _service.CustomQuestion.Create(createCustomQuestionDto);
            return CreatedAtAction(nameof(Create), response);
        }


        /// <summary>
        /// Endpoint to get custom question by type
        /// </summary>
        ///   /// <param name="customQuestionType"></param> 
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(SuccessResponse<CustomQuestionDto>), 200)]
        public async Task<IActionResult> Get([FromQuery] string customQuestionType)
        {
            var response = await _service.CustomQuestion.Get(customQuestionType);
            return Ok(response);
        }
    }
}
