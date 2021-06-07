using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Interfaces.Repositories
{
	public interface IRepository
    {
		
		void Add<T>(T entity) where T:class;
        void Delete<T>(int id)where T:class;
        void Update<T>(T entity) where T : class;
        dynamic SaveChangesAsync();
        T GetAsyncById<T>(string Id) where T : class;
		T[] GetAllAsync<T>() where T : class;
	}
}
