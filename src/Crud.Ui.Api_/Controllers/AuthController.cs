using Crud.ApplicationCore.Entity.Dtos;
using Crud.DTOS.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Ui.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AuthController : Controller
	{
		private readonly IIAuthService authService;

		public AuthController(IIAuthService _authService)
		{
			authService = _authService;
		}

		[HttpPost("Login")]
		public string Login(UsuarioDto usuario)
		{
			return authService.Login(usuario);

		}
	}
}
