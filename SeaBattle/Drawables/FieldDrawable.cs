using SeaBattle.Models;

namespace SeaBattle.Drawables;

public class FieldDrawable : IDrawable
{
    public Models.Cell[,] Field;

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

                if (Field is not null)
                {
                    if (Field[i, j].State == CellState.Empty || Field[i, j].State == CellState.NearShip)
                        canvas.FillColor = Colors.Black;
                    else if (Field[i, j].State == CellState.Ship)
                        canvas.FillColor = Colors.DarkViolet;
                    else if (Field[i, j].State == CellState.Miss)
                        canvas.FillColor = Colors.White;
                }

                canvas.FillRectangle(rectX, rectY, cellWidth, cellHeight);
                canvas.DrawRectangle(rectX, rectY, cellWidth, cellHeight);
            }
    }
}