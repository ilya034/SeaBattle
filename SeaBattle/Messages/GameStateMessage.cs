using CommunityToolkit.Mvvm.Messaging.Messages;
using SeaBattle.Models;

namespace SeaBattle.Messages;

public class GameStateMessage : ValueChangedMessage<GameState>
{
    public GameStateMessage(GameState value) : base(value)
    {
    }
}