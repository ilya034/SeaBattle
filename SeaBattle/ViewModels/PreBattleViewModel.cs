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
        GameState.MakeRandomPlayerPlacement();
        _sharedDataService.UpdateData(GameState);
    }

    [RelayCommand]
    public void GoToBattlePage()
    {
        if (GameState.Player1.Field.IsReady)
            Shell.Current.GoToAsync(nameof(BattlePage));
    }
}
