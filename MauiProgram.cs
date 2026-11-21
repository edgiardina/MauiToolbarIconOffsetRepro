using Microsoft.Extensions.Logging;

namespace MauiToolbarTitleRepro;

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
				// Fluent System Icons (MIT, github.com/microsoft/fluentui-system-icons), as used by the app this came from.
				fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
