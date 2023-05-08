using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace InstantFood;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("WorkSans-Italic-VariableFont_wght.ttf", "WorkSans-Italic");
				fonts.AddFont("WorkSans-VariableFont_wght.ttf", "WorkSans-VariableFon");
				fonts.AddFont("Roboto-BoldItalic.ttf", "Roboto-BI");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

