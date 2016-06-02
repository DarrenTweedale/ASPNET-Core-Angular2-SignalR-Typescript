using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors.Infrastructure;
using AspNetCoreAngular2.Services;
using AspNetCoreAngular2.Repositories;
using AutoMapper;
using AspNetCoreAngular2.Models;
using AspNetCoreAngular2.ViewModels;

namespace AspNetCoreAngular2
{
    public class Startup
	{
	   public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; set; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			//Add Cors support to the service
			services.AddCors();

			var policy = new CorsPolicy();

			policy.Headers.Add("*");
			policy.Methods.Add("*");
			policy.Origins.Add("*");
			policy.SupportsCredentials = true;

			services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

			services.Configure<TimerServiceConfiguration>(Configuration.GetSection("TimeService"));


			services.AddSingleton<IFoodRepository, FoodRepository>();
			services.AddSingleton<ITimerService, TimerService>();

			services.AddSignalR(options =>
			{
				options.Hubs.EnableDetailedErrors = true;
			});

			Mapper.Initialize(mapper =>
			{
				mapper.CreateMap<FoodItem, FoodItemViewModel>().ReverseMap();
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseCors("corsGlobalPolicy");

			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseDefaultFiles();

			app.UseStaticFiles();
			app.UseMvc();
			app.UseSignalR();
		}

		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
