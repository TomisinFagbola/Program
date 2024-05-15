using Application.Contracts;
using AutoMapper;
using Infrastructure.Contracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICustomQuestionService> _customQuestionService;
    private readonly Lazy<IApplicationService> _applicationService;

    public ServiceManager(IRepositoryManager repositoryManager,
   IMapper mapper ,ILogger<CustomQuestionService> customQuestionLogger,
        ILogger<ApplicationService> applicationServiceLogger)
    {
        _customQuestionService =
            new Lazy<ICustomQuestionService>(
                () => new CustomQuestionService(repositoryManager, mapper, customQuestionLogger));

        _applicationService = new Lazy<IApplicationService>(
                () => new ApplicationService(repositoryManager, mapper, applicationServiceLogger));
    }


    public ICustomQuestionService CustomQuestion => _customQuestionService.Value;
    public IApplicationService Application=> _applicationService.Value;
}
