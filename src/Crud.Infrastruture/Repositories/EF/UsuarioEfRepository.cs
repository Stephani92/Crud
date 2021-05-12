using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.Infrastruture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastruture.Repositories.EF
{
	public class UsuarioEfRepository : EfRepository, IUsuarioRepository
	{
		public UsuarioEfRepository(CrudContext _data) : base(_data)
		{
		}
	}
}
