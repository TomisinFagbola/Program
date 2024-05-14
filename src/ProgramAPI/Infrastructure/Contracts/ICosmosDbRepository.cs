using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts;
    public interface ICosmosDbRepository<T> where T : class
    {
        Task AddAsync(T newEntity);
        Task<T> GetAsync(string entityId);
        public Task UpdateAsync(string id, T item);
        Task DeleteAsync(string entityId);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<bool> ValidateItems(QueryDefinition query);

        Task<T> GetItemByQueryAsync(QueryDefinition query);
    }

