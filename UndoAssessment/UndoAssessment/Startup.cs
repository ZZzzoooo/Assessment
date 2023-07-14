using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using UndoAssessment.Configuration;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.ViewModels;
using Xamarin.Essentials;

namespace UndoAssessment
{
	public class Startup
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static void Init()
		{
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream("UndoAssessment.appsettings.json");

			if (stream is null)
				return;

			var host = new HostBuilder()
				.ConfigureHostConfiguration(c =>
				{
					c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
					c.AddJsonStream(stream);
				})
				.ConfigureServices(ConfigureServices)
				.ConfigureLogging(l => l.AddConsole(opt => { opt.DisableColors = true; }))
				.Build();

			ServiceProvider = host.Services;
		}

		private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			services.Configure<AssessmentConfiguration>(ctx.Configuration.GetSection(nameof(AssessmentService)));

			services.AddHttpClient<AssessmentService>()
				.AddTransientHttpErrorPolicy(builder => builder
					.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

			if (ctx.HostingEnvironment.IsDevelopment())
				services.AddSingleton<IDataStore<Item>, MockDataStore>();
			
			services.AddSingleton<IDataStore<User>, UserDataStore>();
			services.AddTransient<AssessmentService>();

			services.AddTransient<LoginViewModel>();
			services.AddTransient<ItemsViewModel>();
			services.AddTransient<ItemDetailViewModel>();
			services.AddTransient<AboutViewModel>();
			services.AddTransient<NewItemViewModel>();
			services.AddTransient<AssessmentViewModel>();
			services.AddTransient<CreateUserViewModel>();
		}
	}
}