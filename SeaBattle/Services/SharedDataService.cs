using SeaBattle.Models;

namespace SeaBattle.Services;

public partial class SharedDataService : ObservableObject
{
    [ObservableProperty]
    GameState _gameStateData;

    // public event Action<GameState> DataChanged;

    public void UpdateData(GameState newData)
    {
        GameStateData = newData;
        // DataChanged?.Invoke(newData);
    }
}
