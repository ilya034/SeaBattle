namespace SeaBattle.Models;

public partial class GameState : ObservableObject
{
    public static int FieldSize = 10;
    public static int[] ShipsSize = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    [ObservableProperty]
    Player _player1;

    [ObservableProperty]
    Player _player2;

    private PlayersManager _playersManager;

    public GameState()
    {
        Player1 = new Player();
        Player2 = new Bot();
        _playersManager = new PlayersManager([Player1, Player2]);
    }

    public void MakeRandomPlayerPlacement()
    {
        Player1.Field.MakeRandomPlacement();
    }

    public void Shoot(Player player, PointF pos)
    {
        if (player != _playersManager.GetCurrentPlayer()) return;

        var enemy = _playersManager.Next();

        var target = enemy.Field.Cells[(int)pos.X, (int)pos.Y];

        if (target.State == CellState.Miss || target.State == CellState.Destroyed)
            _playersManager.Next();
        else if (target.State == CellState.Empty || target.State == CellState.NearShip)
            target.State = CellState.Miss;
        else if (target.State == CellState.Ship)
        {
            target.State = CellState.Destroyed;
            _playersManager.Next();
            player.Score++;
        }

        if (_playersManager.GetCurrentPlayer() == Player2)
            Shoot(Player2, (Player2 as Bot).GetRandomPosition());
    }
}