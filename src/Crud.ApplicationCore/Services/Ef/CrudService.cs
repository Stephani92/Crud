
using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Services.Ef
{
	public class CrudService : ICrudService 
	{
		protected readonly IRepository efRepository;

		public CrudService(IRepository efRepository)
		{
			this.efRepository = efRepository;
		}

		public dynamic Add<T>(T entity) where T : class
		{
			efRepository.Add(entity);
			return efRepository.SaveChangesAsync();
		}

		public dynamic delete<T>(string entity) where T : class
		{
			efRepository.Delete<T>(entity);
			return efRepository.SaveChangesAsync();
		}

		public T[] GetAllAsync<T>() where T : class
		{
			return efRepository.GetAllAsync<T>();
		}

		public T GetAsyncById<T>(string Id) where T : class
		{
			return efRepository.GetAsyncById<T>(Id);
		}

		

		public dynamic Update<T>(T entity) where T : class
		{
			efRepository.Update(entity);
			return efRepository.SaveChangesAsync();
		}
	}
}
