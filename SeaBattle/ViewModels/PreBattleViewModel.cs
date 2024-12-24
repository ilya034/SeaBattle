using CommunityToolkit.Mvvm.Messaging;
using SeaBattle.Messages;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class PreBattleViewModel : BaseViewModel
{
    [ObservableProperty]
    GameState _gameState = new();

    [RelayCommand]
    public void MakeRandomPlayerPlacement()
    {
        GameState.MakeRandomPlayerPlacement(GameState.Player1);
    }

    [RelayCommand]
    public void GoToBattlePage()
    {
        Shell.Current.GoToAsync(nameof(BattlePage));
        WeakReferenceMessenger.Default.Send(new GameStateMessage(GameState));
    }
}
