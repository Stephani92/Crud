using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Crud.UI.Api
{
	internal class GlobalExceptionHandlerMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (System.Exception ex)
			{
				await context.Response.WriteAsync($"Erro: {ex.Message} \n StackTrace: {ex.StackTrace}");
			}
		}
	}
}