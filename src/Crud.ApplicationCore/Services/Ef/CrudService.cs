using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Services.Ef
{
	public class CrudService : ICrudService 
	{
		private readonly IRepository efRepository;

		public CrudService(IRepository efRepository)
		{
			this.efRepository = efRepository;
		}

		public Task<dynamic> Add<T>(T entity) where T : class
		{
			return efRepository.Add(entity);
		}

		public Task<dynamic> delete<T>(int entity) where T : class
		{
			return efRepository.delete<T>(entity);
		}

		public async Task<T[]> GetAllAsync<T>() where T : class
		{
			return await efRepository.GetAllAsync<T>();
		}

		public async Task<T> GetAsyncById<T>(int Id) where T : class
		{
			return await efRepository.GetAsyncById<T>(Id);
		}

		

		public Task<dynamic> Update<T>(T entity) where T : class
		{
			return efRepository.Update(entity);
		}
	}
}
