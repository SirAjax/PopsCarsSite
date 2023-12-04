using Microsoft.EntityFrameworkCore;

namespace EFTest.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _gdb;
        DbSet<T> _entity = null;
        public GenericRepository(DbContext gdb)
        {
            _gdb = gdb;
            _entity = _gdb.Set<T>();
        }
        public bool Add(T model)
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

        public bool Delete(T model)
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

        public bool Update(T model)
        {
            try
            { 
                _entity.Update(model);
                _gdb.SaveChanges();
                return true;
            }

            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
