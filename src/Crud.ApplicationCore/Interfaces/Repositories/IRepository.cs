using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Interfaces.Repositories
{
	public interface IRepository
    {
		
		Task<dynamic> Add<T>(T entity) where T:class;
        Task<dynamic> delete<T>(int id)where T:class;
        Task<dynamic> Update<T>(T entity) where T : class;
        Task<dynamic> SaveChangesAsync();
        Task<T> GetAsyncById<T>(int Id) where T : class;
		Task<T[]> GetAllAsync<T>() where T : class;
	}
}
