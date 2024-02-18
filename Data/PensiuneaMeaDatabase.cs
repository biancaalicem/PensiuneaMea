using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensiuneaMea.Models;

namespace PensiuneaMea.Data
{
    public class PensiuneaMeaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public PensiuneaMeaDatabase(string dbPath)
        { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PachetSejur>().Wait();
            _database.CreateTableAsync<CaracteristiciPachet>().Wait();
            _database.CreateTableAsync<ListCaracteristiciPachet>().Wait();
            _database.CreateTableAsync<AlegerePachet>().Wait();

        }
        public Task<List<AlegerePachet>> GetAlegerePacheteAsync()
        {
            return _database.Table<AlegerePachet>().ToListAsync();
        }
        public Task<int> SaveAlegerePachetAsync(AlegerePachet alegerePachet)
        {
            if(alegerePachet.ID != 0)
            {
                return _database.UpdateAsync(alegerePachet);
            }
            else
            {
                return _database.InsertAsync(alegerePachet);
            }
        }
        public Task<int> SaveCaracteristiciPachetAsync(CaracteristiciPachet caracteristiciPachet)
        {
            if(caracteristiciPachet.ID !=0)
            {
                return _database.UpdateAsync(caracteristiciPachet);
            }
            else
            {
                return _database.InsertAsync(caracteristiciPachet);
            }
        }
        public Task<int> DeleteCaracteristiciPachetAsync(CaracteristiciPachet caracteristiciPachet)
        {
            return _database.DeleteAsync(caracteristiciPachet);
        }
        public Task<List<CaracteristiciPachet>>GetCaracteristiciPacheteAsync()
        {
            return _database.Table<CaracteristiciPachet>().ToListAsync();
        }
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
        public Task<int> SaveListCaracteristiciPachetAsync(ListCaracteristiciPachet listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<CaracteristiciPachet>> GetListCaracteristiciPacheteAsync(int shoplistid)
        {
            return _database.QueryAsync<CaracteristiciPachet>("select P.ID, P.Description from CaracteristiciPachet P" + " inner join ListCaracteristiciPachet LP" + " on P.ID = LP.CaracteristiciPachetID where LP.PachetSejurID = ?", shoplistid);
        }
    }
}
