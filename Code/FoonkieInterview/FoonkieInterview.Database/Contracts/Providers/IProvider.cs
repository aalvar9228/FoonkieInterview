using FoonkieInterview.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Database.Contracts.Providers
{
    public interface IProvider<TEntity> where TEntity : EntityBase
    {
        Task<List<TEntity>> GetItemsAsync();
        Task SaveItemAsync(TEntity item);
        Task SaveItemCollectionAsync(List<TEntity> items);
    }
}
