using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Services.Ef;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Ui.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	[Authorize(Roles = "ADM")]
	public class CondutorController : Controller
	{
		private readonly ICondutoresService CondutoresService;

		public CondutorController(ICondutoresService condutoresService)
		{
			CondutoresService = condutoresService;
		}

		[HttpPost("add")]
		public IActionResult CreateVeiculosCondutores(Condutor VeiculosCondutores)
		{
			CondutoresService.Add(VeiculosCondutores);
			return Created("", VeiculosCondutores);
		}
		[HttpDelete]
		public IActionResult DeleteVeiculosCondutores(Condutor VeiculosCondutores)
		{
			CondutoresService.delete<Condutor>(VeiculosCondutores.CPF);
			return Ok();
		}
		[HttpPut("Update")]
		public IActionResult UpdateVeiculosCondutores(Condutor VeiculosCondutores)
		{
			CondutoresService.Update(VeiculosCondutores);
			return Ok(VeiculosCondutores);
		}
	}
}
