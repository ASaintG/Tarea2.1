using Microsoft.Extensions.Logging;

using Tarea2._1.servicios;
namespace Tarea2._1
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()

				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
                .UseMauiMaps();
				builder.Services.AddSingleton<CountryService,CountryServices>();
				builder.Services.AddTransient<MainPage>();
			;	
		

            builder.Logging.AddDebug();


			return builder.Build();
		}
	}
}
