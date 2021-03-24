using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuickResponse.Table;

namespace QuickResponse.Table
{
    public class Database
    {
         SQLiteAsyncConnection database;

        public Database(string dbPath) 
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<RegUserTable>().Wait();
        }

        public Task<List<RegUserTable>> GetPeopleAsync() 
        {
            return database.Table<RegUserTable>().ToListAsync();
            
        }

        public Task<int> SavePersonAsync(RegUserTable regTrustee) 
        {
            return database.InsertAsync(regTrustee);
        }
    }
}
