using PopsCarsSite.Common.Models;

namespace EFTest.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<CommonResponse<IEnumerable<T>>> GetAll();
		T GetById(int id);
		Task<CommonResponse<T>> Add(T model);
        Task<CommonResponse<T>> UpdateAsync(T model);
     
        Task<CommonResponse<bool>> Delete(T model);
    }
}
