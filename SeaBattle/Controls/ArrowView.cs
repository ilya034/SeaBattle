namespace SeaBattle.Controls;

public class ArrowView : GraphicsView, IDrawable
{


    public ArrowView()
    {
        this.Drawable = this;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        throw new NotImplementedException();
    }
}