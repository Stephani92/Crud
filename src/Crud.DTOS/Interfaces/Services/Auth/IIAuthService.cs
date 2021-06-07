using Crud.ApplicationCore.Entity.Dtos;
using Crud.DTOS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DTOS.Interfaces.Services.Auth
{
	public interface IIAuthService
	{
		void Create(Usuario usuario);
		string Login(UsuarioDto usuario);
	}
}
