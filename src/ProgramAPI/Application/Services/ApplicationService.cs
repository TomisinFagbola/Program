using Application.Contracts;
using Application.Dtos.AdditionalQuestionDtos;
using Application.Dtos.ApplicationDtos;
using Application.Dtos.CustomQuestionDtos;
using Application.Dtos.PersonalInformation;
using Application.Helpers;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using Infrastructure.Queries;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class ApplicationService(IRepositoryManager repository,
            IMapper mapper, ILogger<ApplicationService> logger) : IApplicationService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ApplicationService> _logger = logger;

        /// <summary>
        /// Create application
        /// </summary>
        /// <param name="createApplicationDto"></param>
        /// <returns>ApplicationDto</returns>
        public async Task<SuccessResponse<ApplicationDto>> Create(CreateApplicationDto createApplicationDto)
        {
            _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} New Request to CreateApplicationDto, {createApplicationDto}");
            var applicationValidator = new ApplicationValidator();
            var validationResult = applicationValidator.Validate(createApplicationDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

                _logger.LogInformation("Email: {Email} Validation Failed while creating application reason being: {Reason}", createApplicationDto.PersonalInformation.Email, string.Join("; ", errors));

                throw new RestException(HttpStatusCode.BadRequest, " Unable to create application", errors);
            }

            await ValidateQuestion(createApplicationDto.AdditionalQuestions);
            if (await IsEmailExist(createApplicationDto.PersonalInformation.Email))
                Guard.AgainstDuplicate(createApplicationDto, "You can't create Application, Email Exist");

            var application = _mapper.Map<ProgramApplication>(createApplicationDto);
            await _repository.Application.AddAsync(application);
            var applicationResponse = _mapper.Map<ApplicationDto>(application);

            return new SuccessResponse<ApplicationDto>
            {
                Data = applicationResponse,
                Message = "Application Created successfully created",
                Success = true

            };
        }

        /// <summary>
        /// Update application
        /// </summary>
        /// <param name="updateApplication"></param>
        /// <returns>ApplicationDto</returns>
        public async Task<SuccessResponse<ApplicationDto>> Update(UpdateApplicationDto updateApplication, string id)
        {

            _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} New Request to UpdateApplicatio, {updateApplication}");

            var application = await _repository.Application.GetAsync(id);
            Guard.AgainstNull(application);
            await ValidateQuestion(updateApplication.AdditionalQuestions);
            var updatedApplication =_mapper.Map(updateApplication, application);

            await _repository.Application.UpdateAsync(id, updatedApplication);

            var response = _mapper.Map<ApplicationDto>(updatedApplication);
            return new SuccessResponse<ApplicationDto>
            {
                Data = response,
                Message = "Application Updated successfully",
                Success = true

            };

        }
        #region reusables
        private async Task<bool> IsEmailExist(string email)
        {
            var sqlEmail = SqlQuery.Email;
            var query = new QueryDefinition(sqlEmail).WithParameter("@email", email);
            bool emailExist = await _repository.Application.ValidateItems(query);
            return emailExist;
        }

        private async Task ValidateQuestion(List<AdditionalQuestionDto> additionalQuestionDtos)
        {
            List<string> errors = new();
            foreach(var question in additionalQuestionDtos)
            { 
                var customQuestions = await _repository.CustomQuestion.GetAllAsync();
                var existingCustomQuesion = customQuestions.FirstOrDefault( x => x.Id ==  question.Id );
                if (existingCustomQuesion is null)
                    errors.Add(existingCustomQuesion.Id);

          
            }

            if (errors.Any())
                throw new RestException(HttpStatusCode.BadRequest, " Unable to create application invalid Custom Question Id", errors);
        }
        #endregion
    }
}
