using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        bool Add(T model);
        bool Update(T model);
        T GetById(int id);
        
        bool Delete(T model);
    }
}
