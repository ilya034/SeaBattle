using SeaBattle.Services;

namespace SeaBattle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<PreBattleViewModel>();

		builder.Services.AddSingleton<PreBattlePage>();

		builder.Services.AddSingleton<BattleViewModel>();

		builder.Services.AddSingleton<BattlePage>();

        builder.Services.AddSingleton<ViewModelLocator>();

        return builder.Build();
	}
}
