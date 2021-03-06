using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.ApplicationCore.Services.Auth;
using Crud.ApplicationCore.Services.Ef;
using Crud.DTOS.Interfaces.Repositories;
using Crud.DTOS.Interfaces.Services.Auth;
using Crud.DTOS.Interfaces.Services.Ef;
using Crud.Infrastruture.Data;
using Crud.Infrastruture.Repositories.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

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
				x=> { x.UseSqlServer(Configuration.GetConnectionString("Default"));
						}

				);
			services.AddScoped<IRepository, DefaultEfRepository>();
			services.AddScoped<IUsuarioEfRepository, UsuarioEfRepository>();
			services.AddScoped<ICrudService, CrudService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			services.AddScoped<IIAuthService, AuthService>();
			services.AddScoped<IVeiculoCondutorEfRepository, VeiculoCondutorEfRepository>();
			services.AddScoped<ICondutoresService, CondutoresService>();
			services.AddScoped<IVeiculoService, VeiculoService>();
			services.AddScoped<IVeiculoCondutorService, VeiculoCondutorService>();
			services.AddScoped<GlobalExceptionHandlerMiddleware>();

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				Formatting = Newtonsoft.Json.Formatting.Indented,
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			};
			services.AddMvc(options =>
			{
				var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
				options.Filters.Add(new AuthorizeFilter(policy));
			});
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
								.GetBytes("SuperSecretKeyssssssssssssssssssssssssssssss"))
						,
						ValidateIssuer = false,
						ValidateAudience = false
					};
				}
				);
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
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
