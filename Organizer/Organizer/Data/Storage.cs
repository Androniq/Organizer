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
            await _connection.CreateTableAsync<Item>();
        }

        public async Task WriteText(string text)
        {
            var item = await _connection.FindAsync<Item>(it => true);
            if (item == null)
            {
                await _connection.InsertAsync(new Item { Text = text });
            }
            else
            {
                item.Text = text;
                await _connection.UpdateAsync(item);
            }
        }

        public async Task<string> ReadText()
        {
            var item = await _connection.FindAsync<Item>(it => true);
            return item?.Text;
        }
    }
}
