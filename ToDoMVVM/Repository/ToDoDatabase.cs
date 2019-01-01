using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ToDoMVVM.Models;

namespace ToDoMVVM.Repository
{
    public class ToDoDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ToDoDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ToDo>().Wait();
        }

        public Task<List<ToDo>> GetItemsAsync()
        {
            return database.Table<ToDo>().ToListAsync();
        }

        public Task<ToDo> GetItemAsync(int id)
        {
            return database.Table<ToDo>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDo item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> UpdateItemAsync(ToDo item)
        {
            return database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(ToDo item)
        {
            return database.DeleteAsync(item);
        }

    }
}
