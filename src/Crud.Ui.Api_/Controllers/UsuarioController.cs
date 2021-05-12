using Crud.ApplicationCore.Entity;
using Crud.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crud.UI.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService usuarioService;

		public UsuarioController(IUsuarioService _usuarioService)
		{
			usuarioService = _usuarioService;
		}

		

		// GET api/<UsuarioController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var result = await usuarioService.GetAsyncById<Usuario>(id);
				if (result != null)
				{
					return Ok(result);
				}
				else
				{
					return NoContent();
				}

			}
			catch (Exception e)
			{

				return Conflict(e);
			}
		}
		[HttpGet("getall")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var result = await usuarioService.GetAllAsync<Usuario>();
				if (result != null)
				{
					return Ok(result);
				}
				else
				{
					return NoContent();
				}

			}
			catch (Exception e)
			{

				return Conflict(e);
			}
			
		}

		// POST api/<UsuarioController>
		[HttpPost]
		public async Task<IActionResult> Post(Usuario usuario)
		{
			try
			{
				var result = await usuarioService.Add(usuario);
				
				if (result)
				{
					return Created("",usuario);
				}
				else
				{
					return BadRequest(result);
				}

			}
			catch (Exception e)
			{

				return Conflict(e);
			}
		}

		// PUT api/<UsuarioController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(Usuario usuario)
		{
			try
			{
				var result = await usuarioService.Update<Usuario>(usuario);
				if (result != null)
				{
					return Ok(usuario); ;
				}
				else
				{
					return BadRequest(result);
				}

			}
			catch (Exception e)
			{

				return Conflict(e);
			}
		}

		// DELETE api/<UsuarioController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var result = await usuarioService.delete<Usuario>(id);
				if (result != null)
				{
					return Ok($"Deletado com sucesso \r- Id: {id}");
				}
				else
				{
					return BadRequest(result);
				}

			}
			catch (Exception e)
			{

				return Conflict(e);
			}
		}
	}
}
