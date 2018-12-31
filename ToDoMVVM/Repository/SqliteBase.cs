using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ToDoMVVM.Persistence
{
    public class SqliteBase
    {
        readonly SQLiteAsyncConnection database;

        public SqliteBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<T>().Wait();
        }

        public Task<List<T>> GetItemsAsync()
        {
            return database.Table<ToDo>().ToListAsync();
        }

        /*
        public Task<List<ToDo>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ToDo>("SELECT * FROM [TodoItem]");
        }
        */

        public Task<T> GetItemAsync(int id)
        {
            return database.Table<T>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(T item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return database.DeleteAsync(item);
        }
    }
}
