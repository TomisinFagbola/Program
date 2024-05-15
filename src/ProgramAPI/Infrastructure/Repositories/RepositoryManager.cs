using Infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class RepositoryManager : IRepositoryManager
{
    //private readonly CosmosClient _cosmosClient;
    private readonly IConfiguration _configuration;
    private readonly Lazy<ICustomQuestionRepository> _customQuestionRepository;
    private readonly Lazy<IApplicationRepository> _applicationRepository;

    public RepositoryManager(IConfiguration configuration)
    {
        //_cosmosClient = cosmosClient;
        _configuration = configuration;
        _customQuestionRepository = new Lazy<ICustomQuestionRepository>(() => new CustomQuestionRepository(_configuration));
        _applicationRepository = new Lazy<IApplicationRepository>(() => new ApplicationRepository(_configuration));
    }



    public IApplicationRepository Application => _applicationRepository.Value;

    public ICustomQuestionRepository CustomQuestion => _customQuestionRepository.Value;

}

