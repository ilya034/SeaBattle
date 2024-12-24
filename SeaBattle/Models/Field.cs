namespace SeaBattle.Models;

public partial class Field : ObservableObject
{
    [ObservableProperty]
    Cell[,] _cells;

    [ObservableProperty]
    bool _isReady;

    public Field()
    {
        CreateEmptyField();
        IsReady = false;
    }

    public void SetPlacement(Cell[,] cells)
    {
        ArgumentNullException.ThrowIfNull(cells);
        Cells = cells;
    }

    public void MakeRandomPlacement()
    {
        CreateEmptyField();

        foreach (var size in GameState.ShipsSize)
        {
            bool placed = false;
            while (!placed)
            {
                var ship = Ship.CreateRandomShip(size);
                if (IsValidShipPlacement(ship, Cells))
                {
                    PlaceNewShip(ship, Cells);
                    placed = true;
                }
            }
        }

        IsReady = true;
    }

    public void CreateEmptyField()
    {
        Cells = new Cell[GameState.FieldSize, GameState.FieldSize];
        for (int i = 0; i < GameState.FieldSize; i++)
            for (int j = 0; j < GameState.FieldSize; j++)
                Cells[i, j] = new Cell(i, j, CellState.Empty);
        IsReady = false;
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