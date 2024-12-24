using SeaBattle.Models;

namespace SeaBattle.Drawables;

public class FieldDrawable : IDrawable
{
    public Models.Cell[,] Cells;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        int cellWidth = (int)dirtyRect.Width / GameState.FieldSize;
        int cellHeight = (int)dirtyRect.Height / GameState.FieldSize;

        canvas.StrokeColor = Colors.White;
        for (int i = 0; i < GameState.FieldSize; i++)
            for (int j = 0; j < GameState.FieldSize; j++)
            {
                int rectX = i * cellWidth;
                int rectY = j * cellHeight;

                if (Cells is not null)
                {
                    if (Cells[i, j].State == CellState.Empty || Cells[i, j].State == CellState.NearShip)
                        canvas.FillColor = Colors.Black;
                    else if (Cells[i, j].State == CellState.Ship)
                        canvas.FillColor = Colors.DarkViolet;
                    else if (Cells[i, j].State == CellState.Miss)
                        canvas.FillColor = Colors.White;
                }

                canvas.FillRectangle(rectX, rectY, cellWidth, cellHeight);
                canvas.DrawRectangle(rectX, rectY, cellWidth, cellHeight);
            }
    }
}