using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class PreBattleViewModel : BaseViewModel
{
    [ObservableProperty]
    Models.Cell[,] _field = GameState.CreateEmptyField();

    [RelayCommand]
    public void MakeRandomPlayerPlacement()
    {
        Field = GameState.CreateRandomField();
    }

    [RelayCommand]
    public void GoToBattlePage()
    {
        Shell.Current.GoToAsync(nameof(BattlePage));
    }
}
