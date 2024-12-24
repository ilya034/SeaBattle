namespace SeaBattle.Models;
public partial class Player : ObservableObject
{
    public int Score;
    [ObservableProperty]
    public Cell[,] _field = GameState.CreateEmptyField();
}