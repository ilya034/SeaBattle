namespace SeaBattle;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        Routing.RegisterRoute(nameof(PreBattlePage), typeof(PreBattlePage));
        Routing.RegisterRoute(nameof(BattlePage), typeof(BattlePage));
    }
}
