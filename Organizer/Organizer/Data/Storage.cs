using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Organizer.Models;
using SQLite;

namespace Organizer.Data
{
    public class Storage
    {
        private readonly SQLiteAsyncConnection _connection;

        public Storage()
        {
            var applicationFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var databaseFileName = System.IO.Path.Combine(applicationFolderPath, "Organizer.db");

            _connection = new SQLiteAsyncConnection(databaseFileName);
        }

        public async Task Init()
        {
            await CreateTables();
        }

        private async Task CreateTables()
        {
            await _connection.CreateTableAsync<TaskModel>();
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await _connection.Table<TaskModel>().ToListAsync();
        }
    }
}
