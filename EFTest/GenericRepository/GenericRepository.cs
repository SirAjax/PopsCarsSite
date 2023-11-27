using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTest;

namespace EFTest.GenericRepository
{
    

    public (DatabaseContext ctx)
        
       
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public bool Add(T model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
