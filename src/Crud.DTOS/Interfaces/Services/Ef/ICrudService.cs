using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Interfaces.Services
{
	public interface ICrudService
	{
		dynamic Add<T>(T entity) where T : class;
		dynamic delete<T>(int id) where T : class;
		dynamic Update<T>(T entity) where T : class;
		T GetAsyncById<T>(string Id)where T : class;
		T[] GetAllAsync<T>() where T : class;
	}
}
