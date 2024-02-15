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
        public async Task<T> Add(T model)
        {
            try
            {
                _entity.Add(model);
                _gdb.SaveChanges();
                return model;
            }

            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<T> Delete(T model)
        {
            try
            {
                _gdb.Remove(model);
                _gdb.SaveChanges();
                return model;
            }
            catch (Exception ex) 
            {
                return model;
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

        public async Task<T> UpdateAsync(T model)
        {
            try
            {
                _entity.Update(model);
                await _gdb.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }
    }
}
