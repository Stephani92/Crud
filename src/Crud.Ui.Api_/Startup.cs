using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.ApplicationCore.Services.Ef;
using Crud.Infrastruture.Data;
using Crud.Infrastruture.Repositories.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Crud.UI.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<CrudContext>(
				x=>x.UseSqlServer(Configuration.GetConnectionString("Default"))
				);
			services.AddScoped<IRepository, EfRepository>();
			services.AddScoped<IUsuarioRepository, UsuarioEfRepository>();
			services.AddScoped<ICrudService, CrudService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			services.AddScoped<GlobalExceptionHandlerMiddleware>();
			//services.AddScoped<IRequest, Request>();
			services.AddCors();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();
			app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
			app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			//app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
