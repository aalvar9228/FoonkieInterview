using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoonkieInterview.Database.Providers
{
    public class UserProvider : IUserProvider
    {
        public async Task<List<UserEntity>> GetItemsAsync()
        {
            FoonkieInterviewDatabase databaseInstance = await FoonkieInterviewDatabase.Instance;
            return await databaseInstance.Database.Table<UserEntity>().ToListAsync();
        }

        public async Task SaveItemAsync(UserEntity item)
        {
            FoonkieInterviewDatabase databaseInstance = await FoonkieInterviewDatabase.Instance;
            if (item.Id != 0)
            {
                await databaseInstance.Database.UpdateAsync(item);
            }
            else
            {
                await databaseInstance.Database.InsertAsync(item);
            }
        }

        public async Task SaveItemCollectionAsync(List<UserEntity> items)
        {
            FoonkieInterviewDatabase databaseInstance = await FoonkieInterviewDatabase.Instance;
            await databaseInstance.Database.InsertAllAsync(items);
        }
    }
}
