namespace EFTest.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
		T GetById(int id);
		Task<T> Add(T model);
        Task<T> UpdateAsync(T model);
     
        Task<T> Delete(T model);
    }
}
