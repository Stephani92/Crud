using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.Infrastruture.Repositories.EF
{
	public class DefaultEfRepository : IRepository 
	{
		public readonly CrudContext data;
		public DefaultEfRepository(CrudContext _data)
		{
			data = _data;
			data.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}
		
		
		public void Add<T>(T entity) where T : class
		{
			data.Set<T>().Add(entity);
		}

		public void Delete<T>(string id) where T : class
		{
			T ToDelete = data.Set<T>().FindAsync(id).Result;
			data.Set<T>().Remove(ToDelete);
		}

		public T[] GetAllAsync<T>() where T : class
		{
			return data.Set<T>().OrderBy(x => x).ToArrayAsync().Result;
		}

		public T GetAsyncById<T>(string Id) where T : class
		{
			return data.Set<T>().FindAsync(Id).Result;
		}

		public dynamic SaveChangesAsync()
		{			
			return data.SaveChangesAsync().Result > 0;			
		}

		public void Update<T>(T entity) where T : class
		{
			data.Set<T>().Update(entity);
		}
	}
}
