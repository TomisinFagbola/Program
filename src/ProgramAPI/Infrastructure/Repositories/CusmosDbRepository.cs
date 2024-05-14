using Infrastructure.Contracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class CosmosDbRepository<T>(string containerName,
                    IConfiguration configuration) : ICosmosDbRepository<T> where T : class
{


    private readonly IConfiguration _configuration = configuration
                            ?? throw new ArgumentNullException(nameof(configuration));

    private readonly string _containerName = containerName
                         ?? throw new ArgumentNullException(nameof(containerName));


    public async Task AddAsync(T newEntity)
    {

        Container container = await GetContainer(_configuration);
        await container.CreateItemAsync(newEntity);

    }

    public async Task DeleteAsync(string entityId)
    {

        Container container = await GetContainer(_configuration);

        await container.DeleteItemAsync<T>(entityId, new PartitionKey(entityId));

    }

    public async Task<T> GetAsync(string entityId)
    {

        Container container = await GetContainer(_configuration);

        ItemResponse<T> entityResult = await container.ReadItemAsync<T>(entityId, new PartitionKey(entityId));
        return entityResult.Resource;

    }

    public async Task UpdateAsync(string id, T item)
    {

        Container container = await GetContainer(_configuration);
        await container.UpsertItemAsync(item, new PartitionKey(id));

    }


    public async Task<IReadOnlyList<T>> GetAllAsync()
    {

        Container container = await GetContainer(_configuration);
        var query = container.GetItemQueryIterator<T>();
        List<T> entities = new List<T>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            entities.AddRange(response.ToList());
        }

        return entities;


    }


    public async Task<bool> ValidateItems(QueryDefinition query)
    {
        Container container = await GetContainer(_configuration);
        var iterator = container.GetItemQueryIterator<T>(query);
        while (iterator.HasMoreResults)
        {
            FeedResponse<T> response = await iterator.ReadNextAsync();
            if (response.Any())
            {
                return true;
            }
        }

        return false;

    }


    public async Task<T> GetItemByQueryAsync(QueryDefinition query)
    {

        Container container = await GetContainer(_configuration);

        var iterator = container.GetItemQueryIterator<T>(query);
        T item = null;
        while (iterator.HasMoreResults)
        {
            FeedResponse<T> response = await iterator.ReadNextAsync();
            if (response.Any())
            {
                item = response.FirstOrDefault();
            }
        }
        return item;


    }
    #region Private Methods
    private async Task<Container> GetContainer(IConfiguration configuration)
    {
        string? databaseName = _configuration.GetSection("AzureCosmos")["Database"];
        var client = await InitializeDatabaseAsync();
        var container = client.GetContainer(databaseName, _containerName);
        return container;
    }

    private async Task<CosmosClient> InitializeDatabaseAsync()
    {
        string? accountKey = configuration.GetSection("AzureCosmos")["AccountKey"];
        string? accountEndpoint = configuration.GetSection("AzureCosmos")["AccountEndpoint"];
        var client = new CosmosClient(accountEndpoint, accountKey);
        var result = await client.CreateDatabaseIfNotExistsAsync(configuration.GetSection("AzureCosmos")["Database"]);
        await result.Database.CreateContainerIfNotExistsAsync(_containerName
            , "/id");
        return client;
    }
    #endregion

}




