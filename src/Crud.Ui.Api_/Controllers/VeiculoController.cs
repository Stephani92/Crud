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
	public class VeiculoController : Controller
	{
		private readonly IVeiculoService VeiculoService;

		public VeiculoController(IVeiculoService VeiculoService)
		{
			this.VeiculoService = VeiculoService;
		}

		[HttpPost("add")]
		public IActionResult CreateVeiculosCondutores(Veiculo Veiculos)
		{
			VeiculoService.Add(Veiculos);
			return Created("", Veiculos);
		}
		[HttpDelete]
		public IActionResult DeleteVeiculosCondutores(Veiculo Veiculos)
		{
			VeiculoService.delete<Veiculo>(Veiculos.Placa);
			return Ok();
		}
		[HttpPut("Update")]
		public IActionResult UpdateVeiculosCondutores(Veiculo Veiculos)
		{
			VeiculoService.Update(Veiculos);
			return Ok(Veiculos);
		}
	}
}

