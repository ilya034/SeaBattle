namespace SeaBattle.Models;

public class GameState
{
    public static int FieldSize = 10;
    public static int[] ShipsSize = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    public Player Player1;
    public Player Player2;

    public static Cell[,] CreateEmptyField()
    {
        var cell = new Cell[FieldSize, FieldSize];
        for (int i = 0; i < FieldSize; i++)
            for (int j = 0; j < FieldSize; j++)
                cell[i, j] = new Cell(i, j, CellState.Empty);

        return cell;
    }

    public static Cell[,] CreateRandomField()
    { 
        var cells = CreateEmptyField();

        foreach (var size in ShipsSize)
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

        return cells;
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