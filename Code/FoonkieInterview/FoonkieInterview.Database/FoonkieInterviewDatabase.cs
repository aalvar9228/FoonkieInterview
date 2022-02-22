using FoonkieInterview.Common.Shared;
using FoonkieInterview.Database.Entities;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FoonkieInterview.Database
{
    public class FoonkieInterviewDatabase
    {
        static SQLiteAsyncConnection _database;
        public SQLiteAsyncConnection Database => _database;

        private const string DatabaseFilename = "FoonkieInterview.db3";

        private const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        private string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        public static readonly AsyncLazy<FoonkieInterviewDatabase> Instance = new AsyncLazy<FoonkieInterviewDatabase>(async () =>
        {
            var instance = new FoonkieInterviewDatabase();
            await CreateTables();
            return instance;
        });

        public FoonkieInterviewDatabase()
        {
            _database = new SQLiteAsyncConnection(DatabasePath, Flags);
        }

        #region Private Methods

        private static async Task CreateTables()
        {
            await _database.CreateTableAsync<UserEntity>();
        }

        #endregion
    }
}
