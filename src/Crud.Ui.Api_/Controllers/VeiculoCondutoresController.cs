using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Services.Ef;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Ui.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	[Authorize(Roles = "ADM")]
	public class VeiculoCondutoresController : Controller
	{
		private readonly IVeiculoCondutorService VeiculoCondutorService;

		public VeiculoCondutoresController(IVeiculoCondutorService _authService)
		{
			VeiculoCondutorService = _authService;
		}

		[HttpPost("add")]
		public IActionResult CreateVeiculosCondutores(VeiculoCondutores VeiculosCondutores)
		{
			VeiculoCondutorService.Add(VeiculosCondutores);
			return Created("", VeiculosCondutores);
		}

		[HttpPut("update")]
		public IActionResult UpdateVeiculosCondutores(VeiculoCondutores VeiculosCondutores)
		{
			VeiculoCondutorService.Update(VeiculosCondutores);
			return Ok(VeiculosCondutores);
		}
		[HttpPost("GetHistorioCondutoresVeiculo")]
		public Condutor GetHistorioCondutoresVeiculo([FromBody] string Cpf)
		{
			return VeiculoCondutorService.GetHistorioCondutoresVeiculo(Cpf);
		}
		[HttpPost("GetHistorioVeiculoCondutores")]
		public Veiculo GetHistorioVeiculoCondutores([FromBody] string Placa)
		{
			return VeiculoCondutorService.GetHistorioVeiculoCondutores(Placa);
		}
	}
}
