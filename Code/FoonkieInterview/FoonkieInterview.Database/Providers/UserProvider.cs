using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<int> SaveItemAsync(UserEntity item)
        {
            FoonkieInterviewDatabase databaseInstance = await FoonkieInterviewDatabase.Instance;
            if (item.Id != 0)
            {
                return await databaseInstance.Database.UpdateAsync(item);
            }
            else
            {
                return await databaseInstance.Database.InsertAsync(item);
            }
        }
    }
}
