using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Interfaces.Services
{
	public interface ICrudService
	{
		Task<dynamic> Add<T>(T entity) where T : class;
		Task<dynamic> delete<T>(int id) where T : class;
		Task<dynamic> Update<T>(T entity) where T : class;
		//Task<bool> SaveChangesAsync();
		Task<T> GetAsyncById<T>(int Id)where T : class;
		Task<T[]> GetAllAsync<T>() where T : class;
	}
}
