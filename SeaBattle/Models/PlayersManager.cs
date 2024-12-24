namespace SeaBattle.Models;

public class PlayersManager
{
    int _index;

    List<Player> _players;
    public List<Player> Players
    {
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _players = value;
        }
        get => _players;
    }

    public PlayersManager(List<Player> players)
    {
        Players = players;
    }

    public Player GetCurrentPlayer()
    {
        return Players[_index];
    }

    public Player Next()
    {
        _index++;
        _index %= Players.Count;

        return Players[_index];
    }
}