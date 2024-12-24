namespace SeaBattle.Models;

public partial class Bot : Player
{
    public Bot()
    {
        Field = Field.CreateRandomField();
    }
}