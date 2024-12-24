using SeaBattle.Services;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class BattleViewModel : BaseViewModel
{
    private readonly SharedDataService _sharedDataService;

    [ObservableProperty]
    GameState _gameState = new();

    public BattleViewModel(SharedDataService sharedDataService)
    {
        _sharedDataService = sharedDataService;

        _sharedDataService.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(SharedDataService.GameStateData))
                GameState = _sharedDataService.GameStateData;
        };
        GameState = _sharedDataService.GameStateData;
    }

    public void HandleTap(PointF pos)
    {
        GameState.Shoot(GameState.Player1, new Point((int)pos.X / 50, (int)pos.Y / 50));
    }
}
