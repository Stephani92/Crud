using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Entity.Dtos;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crud.UI.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	[Authorize(Roles = "Master")]
	public class UsuarioController : ControllerBase
	{
		private readonly IIAuthService authService;

		public UsuarioController(IIAuthService _authService)
		{
			authService = _authService;
		}

		[HttpPost("CreateUsuarioAdm")]
		public IActionResult CreateUsuarioAdm(Usuario usuario)
		{
			authService.Create(usuario);
			return Created("", usuario);
		}		
	}
}
