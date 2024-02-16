using Microsoft.EntityFrameworkCore;
using PopsCarsSite.Common.Models;

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
		public async Task<CommonResponse<T>> Add(T model)
		{
			var retVal = new CommonResponse<T>();
			try
			{
				_entity.Add(model);
				_gdb.SaveChanges();
				retVal.Value = model;
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<bool>> Delete(T model)
		{
			var retVal = new CommonResponse<bool>();

			try
			{
				_gdb.Remove(model);
				_gdb.SaveChanges();
				retVal.Value = true;
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<int>> DeleteListAsync(List<T> recordsToDelete)
		{
			var retVal = new CommonResponse<int>();

			try
			{
				_gdb.RemoveRange(recordsToDelete);
				_gdb.SaveChanges();
				retVal.Value = recordsToDelete.Count;
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public async Task<CommonResponse<IEnumerable<T>>> GetAll()
		{
			var retVal = new CommonResponse<IEnumerable<T>>();
			try
			{
				retVal.Value = _entity.ToList();
			}

			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}

			return retVal;
		}

		public T GetById(int id)
		{
			return _entity.Find(id);
		}

		public async Task<CommonResponse<T>> UpdateAsync(T model)
		{
			var retVal = new CommonResponse<T>();
			try
			{
				_entity.Update(model);
				await _gdb.SaveChangesAsync();
				retVal.Value = model;
			}
			catch (Exception ex)
			{
				await retVal.SetExceptionAsync(ex);
			}
            return retVal;
		}
	}
}
