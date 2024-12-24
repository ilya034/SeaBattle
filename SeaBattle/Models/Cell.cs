namespace SeaBattle.Models;

public enum CellState
{
    Empty,
    Ship,
    NearShip,
    Miss
}
public class Cell
{
    public int X;
    public int Y;

    public CellState State;

    public Cell(int x, int y, CellState state)
    {
        X = x;
        Y = y;
        State = state;
    }
}