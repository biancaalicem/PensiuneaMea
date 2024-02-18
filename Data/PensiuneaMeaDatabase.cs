using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using PensiuneaMea.Models;
using System.Threading.Tasks;

namespace PensiuneaMea.Data
{
    public class PensiuneaMeaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public PensiuneaMeaDatabase(string dbPath) { _database = new SQLiteAsyncConnection(dbPath); _database.CreateTableAsync<PachetSejur>().Wait(); }
        public Task<List<PachetSejur>> GetPacheteSejurAsync() { return _database.Table<PachetSejur>().ToListAsync(); }
        public Task<PachetSejur> GetPachetSejurAsync(int id) { return _database.Table<PachetSejur>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SavePachetSejurAsync(PachetSejur slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeletePachetSejurAsync(PachetSejur slist) { return _database.DeleteAsync(slist); }
    }
}
