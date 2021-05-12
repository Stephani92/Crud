using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.Infrastruture.Repositories.EF
{
	public class EfRepository : IRepository 
	{
		public readonly CrudContext data;
		public EfRepository(CrudContext _data)
		{
			data = _data;

		}
		
		
		public async Task<dynamic> Add<T>(T entity) where T : class
		{
			data.Set<T>().Add(entity);
			return await SaveChangesAsync();
		}

		public async Task<dynamic> delete<T>(int id) where T : class
		{
			T ToDelete = await data.Set<T>().FindAsync(id);
			data.Set<T>().Remove(ToDelete);
			return await SaveChangesAsync();
		}

		public async Task<T[]> GetAllAsync<T>() where T : class
		{
			return await data.Set<T>().OrderBy(x => x).ToArrayAsync();
		}

		public async Task<T> GetAsyncById<T>(int Id) where T : class
		{
			return await data.Set<T>().FindAsync(Id);
		}

		public async Task<dynamic> SaveChangesAsync()
		{
			try
			{
				return await data.SaveChangesAsync() > 0;
			}
			catch (DbUpdateException ex)
			{

				return ex;
			}
		}

		public async Task<dynamic> Update<T>(T entity) where T : class
		{
			data.Set<T>().Update(entity);
			return await SaveChangesAsync();
		}
	}
}
