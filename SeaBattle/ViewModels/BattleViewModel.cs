using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class BattleViewModel : BaseViewModel
{
    [ObservableProperty]
    GameState _gameState = new();
}
