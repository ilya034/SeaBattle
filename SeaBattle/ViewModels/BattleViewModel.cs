using CommunityToolkit.Mvvm.Messaging;
using SeaBattle.Messages;
using SeaBattle.Models;

namespace SeaBattle.ViewModels;

public partial class BattleViewModel : BaseViewModel, IRecipient<GameStateMessage>
{
    [ObservableProperty]
    GameState _gameState = new();

    IConnectivity connectivity;
    public BattleViewModel()
    {
        this.connectivity = connectivity;

        WeakReferenceMessenger.Default.Register<GameStateMessage>(this);
    }

    public void Receive(GameStateMessage message)
    {
        GameState = message.Value;
    }
}
