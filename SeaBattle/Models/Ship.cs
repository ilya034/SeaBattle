namespace SeaBattle.Models;

public enum Orientation
{
    Horizontal,
    Vertical
}

public class Ship
{
    public Cell[] Cells;
    public int Size;
    public Orientation Orientation;

    public Ship(Cell[] cells, Orientation orientation)
    {
        Cells = cells;
        Size = cells.Length;
        Orientation = orientation;
    }

    public static Ship CreateRandomShip(int size)
    {
        if (size <= 0 || size > 4) throw new ArgumentOutOfRangeException("incorrect ship size");

        var cells = new Cell[size];

        var random = new Random();
        Orientation orientation = (Orientation)random.Next(2);

        int startX, startY;
        if (orientation == Orientation.Horizontal)
        {
            startX = random.Next(GameState.FieldSize - size + 1);
            startY = random.Next(GameState.FieldSize);
        }
        else
        {
            startX = random.Next(GameState.FieldSize);
            startY = random.Next(GameState.FieldSize - size + 1);
        }

        for (int i = 0; i < size; i++)
        {
            if (orientation == Orientation.Horizontal)
                cells[i] = new Cell(startX + i, startY, CellState.Ship);
            else
                cells[i] = new Cell(startX, startY + i, CellState.Ship);
        }

        return new Ship(cells, orientation);
    }

}