using SeaBattle.Services;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class PreBattleViewModel : BaseViewModel
{
    private readonly SharedDataService _sharedDataService;

    [ObservableProperty]
    GameState _gameState = new();

    public PreBattleViewModel(SharedDataService sharedDataService)
    {
        _sharedDataService = sharedDataService;
    }

    [RelayCommand]
    public void MakeRandomPlayerPlacement()
    {
        GameState.MakeRandomPlayerPlacement(GameState.Player1);
    }

    [RelayCommand]
    public void GoToBattlePage()
    {
        Shell.Current.GoToAsync(nameof(BattlePage));
        _sharedDataService.UpdateData(GameState);
    }
}
