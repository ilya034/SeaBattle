namespace SeaBattle.Models;

public partial class GameState : ObservableObject
{
    public static int FieldSize = 10;
    public static int[] ShipsSize = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    [ObservableProperty]
    Player _player1;

    [ObservableProperty]
    Player _player2;

    public GameState()
    {
        Player1 = new Player();
        Player2 = new Bot();
    }

    public void MakeRandomPlayerPlacement(Player player)
    {
        player.Field = Field.CreateRandomField();
    }
}