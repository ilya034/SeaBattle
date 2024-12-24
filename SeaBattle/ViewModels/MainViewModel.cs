namespace SeaBattle.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [RelayCommand]
    public void GoToPreBattlePage()
    {
        Shell.Current.GoToAsync(nameof(PreBattlePage));
    }

    [RelayCommand]
    public static void GameQuit()
    {
        Application.Current.Quit();
    }
}
