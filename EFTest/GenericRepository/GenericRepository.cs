using Microsoft.EntityFrameworkCore;

namespace EFTest.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _gdb;
        DbSet<T> _entity = null;
        public GenericRepository(DbContext gdb)
        {
            _gdb = gdb;
            _entity = _gdb.Set<T>();
        }
        public async Task<bool> Add(T model)
        {
            try
            {
                _entity.Add(model);
                _gdb.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(T model)
        {
            try
            {
                _gdb.Remove(model);
                _gdb.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public async Task<bool> UpdateAsync(T model)
        {
            try
            {
                _entity.Update(model);
                await _gdb.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
