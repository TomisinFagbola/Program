using Application.Contracts;
using Application.Dtos.CustomQuestionDtos;
using Application.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.EnumExtensions;
using Infrastructure.Contracts;
using Infrastructure.Queries;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.Net;



namespace Application.Services;

public class CustomQuestionService(IRepositoryManager repository,
IMapper mapper, ILogger<CustomQuestionService> logger) : ICustomQuestionService
{
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IRepositoryManager _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly ILogger<CustomQuestionService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));


    /// <summary>
    /// Create Custom Question
    /// </summary>
    /// <param name="createCustomQuestionDto"></param>
    /// <returns>CustomQuestDto</returns>
    public async Task<SuccessResponse<CustomQuestionDto>> Create(CreateCustomQuestionDto createCustomQuestionDto)
    {
        CustomQuestion customQuestion;


        _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} New Request to CreateCustomQuestion, {createCustomQuestionDto}");
        if (createCustomQuestionDto is null)
            throw new RestException(HttpStatusCode.BadRequest, " Custom Question cannot be null or empty");


        if (await IsCustomQuestionTypeExist(createCustomQuestionDto.Type.GetDescription()))
            throw new RestException(HttpStatusCode.BadRequest, " Custom Question with Type name exist");
        
        customQuestion = _mapper.Map<CustomQuestion>(createCustomQuestionDto);
        await _repository.CustomQuestion.AddAsync(customQuestion);
        

        var cutomQuestionResponse = _mapper.Map<CustomQuestionDto>(customQuestion);
        _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} Custom Question created successfully, {cutomQuestionResponse}");
        return new SuccessResponse<CustomQuestionDto>
            {
                Data = cutomQuestionResponse,
                Message = "Data created successfully created",
                Success = true

            };
    }
    /// <summary>
    /// Get Custom Question by Type
    /// </summary>
    /// <param name="customQuestionType"></param>
    /// <returns>CustomQuestDto</returns>
    public async Task<SuccessResponse<CustomQuestionDto>> Get(string customQuestionType)
    {
        _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} New Request to GetCustomQuestion by custQuestionType, {customQuestionType}");
        var sqlType = SqlQuery.Type;
        var query = new QueryDefinition(sqlType).WithParameter("@Type", customQuestionType);
        var customQuestion = await _repository.CustomQuestion.GetItemByQueryAsync(query);
        Guard.AgainstNull(customQuestion);
        var responeCustomQuestion = _mapper.Map<CustomQuestionDto>(customQuestion);
        _logger.LogInformation($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} Successfully  got CustomQuestion by custQuestionType, {responeCustomQuestion}");
        return new SuccessResponse<CustomQuestionDto>
        {
            Data = responeCustomQuestion,
            Message = "Data created successfully created",
            Success = true
        };
    }

  
    #region reusables

    private async Task<bool> IsCustomQuestionTypeExist(string type)
    {
        var sqlType = SqlQuery.Type;
        var query = new QueryDefinition(sqlType).WithParameter("@type", type);
        bool emailExist = await _repository.Application.ValidateItems(query);
        return emailExist;
    }
    #endregion
}