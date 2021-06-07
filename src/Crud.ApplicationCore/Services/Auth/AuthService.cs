using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Entity.Dtos;
using Crud.ApplicationCore.Helpers.Security;
using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Services.Auth
{
	public class AuthService : IIAuthService
	{
		private readonly IUsuarioEfRepository _usuarioRepositorio;

		public AuthService(IUsuarioEfRepository usuarioService)
		{
			_usuarioRepositorio = usuarioService;
		}

		public void Create(Usuario usuario)
		{
			var usuarioValido = _usuarioRepositorio.GetAsyncById<Usuario>(usuario.Email);
			if (usuarioValido is not null) throw new ArgumentException("Email ja cadastrado");

			var roleUsuarioAdm = new List<UserRole>();
			roleUsuarioAdm.Add(
					new UserRole(usuario.Email, "ADM")				
				);
			usuario.PasswordHash = CripAlgoritmo.Criptografar(usuario.PasswordHash);

			usuario.UserRole = roleUsuarioAdm;
			_usuarioRepositorio.Add(usuario);
			_usuarioRepositorio.SaveChangesAsync();
			
		}

		public string Login(UsuarioDto usuario)
		{
			var usuarioValido = _usuarioRepositorio.GetUsuarioAsyncByEmail(usuario.Email);
			if (usuarioValido is null) throw new ArgumentNullException("Email não encontrado");
			var hash = CripAlgoritmo.Criptografar(usuario.Password);
			if(usuarioValido.PasswordHash != hash) throw new ArgumentException("Senha errada");
			return CripAlgoritmo.GenerationJwToken(usuarioValido);
		}
	}
}
