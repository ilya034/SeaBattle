namespace SeaBattle.Models;

public partial class Bot : Player
{
    public Bot()
    {
        Field.MakeRandomPlacement();
    }

    public Point GetRandomPosition()
    {
        var random = new Random();
        return new Point(random.Next(10), random.Next(10));
    }
}