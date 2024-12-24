using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class BattleViewModel : BaseViewModel
{
    [ObservableProperty]
    Models.Cell[,] _player1Field = GameState.CreateEmptyField(); 
    [ObservableProperty]
    Models.Cell[,] _player2Field = GameState.CreateEmptyField();
}
