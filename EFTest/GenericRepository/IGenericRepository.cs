namespace EFTest.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<bool> Add(T model);
        Task<bool> UpdateAsync(T model);
        T GetById(int id);
        
        
        Task<bool> Delete(T model);
    }
}
