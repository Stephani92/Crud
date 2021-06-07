using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.DTOS.Entity;
using Crud.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud.Infrastruture.Repositories.EF
{
	public class UsuarioEfRepository : DefaultEfRepository, IUsuarioEfRepository
	{
		public UsuarioEfRepository(CrudContext _data) : base(_data)
		{
		}
		public Usuario GetUsuarioAsyncByEmail(string UserEmail)
		{
			IQueryable<Usuario> query = data.Usuarios
			.Include(c => c.UserRole)
			.ThenInclude(c => c.Role);
			query = query.Where(c => c.Email == UserEmail);
			return query.FirstOrDefaultAsync<Usuario>().Result;
		}
	}
}
