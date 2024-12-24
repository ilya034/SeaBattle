namespace SeaBattle.Models;

public partial class Field : ObservableObject
{
    public Cell[,] Cells { get; }

    public Field(Cell[,] cells)
    {
        Cells = cells;
    }

    public CellState GetShootResult()
    {
        return CellState.Miss;
    }

    public static Field CreateEmptyField()
    {
        var cells = new Cell[GameState.FieldSize, GameState.FieldSize];
        for (int i = 0; i < GameState.FieldSize; i++)
            for (int j = 0; j < GameState.FieldSize; j++)
                cells[i, j] = new Cell(i, j, CellState.Empty);

        return new Field(cells);
    }

    public static Field CreateRandomField()
    {
        var cells = CreateEmptyField().Cells;

        foreach (var size in GameState.ShipsSize)
        {
            bool placed = false;
            while (!placed)
            {
                var ship = Ship.CreateRandomShip(size);
                if (IsValidShipPlacement(ship, cells))
                {
                    PlaceNewShip(ship, cells);
                    placed = true;
                }
            }
        }

        return new Field(cells);
    }

    public static bool IsValidShipPlacement(Ship ship, Cell[,] cells)
    {
        for (int i = 0; i < ship.Size; i++)
        {
            Cell curCell = cells[ship.Cells[i].X, ship.Cells[i].Y];
            if (curCell.State == CellState.Ship || curCell.State == CellState.NearShip)
                return false;
        }
        return true;
    }

    public static void PlaceNewShip(Ship ship, Cell[,] cells)
    {
        for (int i = 0; i < ship.Size; i++)
        {
            int shipX = ship.Cells[i].X;
            int shipY = ship.Cells[i].Y;
            cells[shipX, shipY].State = CellState.Ship;

            for (int x = -1; x < 2; x++)
            {
                int nearX = shipX + x;
                if (nearX < 0 || nearX >= GameState.FieldSize) continue;

                for (int y = -1; y < 2; y++)
                {
                    int nearY = shipY + y;
                    if (nearY < 0 || nearY >= GameState.FieldSize) continue;

                    if (cells[nearX, nearY].State != CellState.Ship)
                        cells[shipX + x, shipY + y].State = CellState.NearShip;
                }
            }
        }
    }
}