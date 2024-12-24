using SeaBattle.Drawables;
using SeaBattle.Models;

namespace SeaBattle.Controls;

public partial class FieldView : GraphicsView
{
    public static BindableProperty ShouldDrawShipsProperty = BindableProperty.Create(nameof(ShouldDrawShips),
        typeof(bool), typeof(FieldView), defaultValue: true, propertyChanged: static (bindable, oldValue, newValue) =>
        {
            ((FieldView)bindable).Invalidate();
        });

    public static BindableProperty CellsProperty = BindableProperty.Create(nameof(Cells),
        typeof(Models.Cell[,]), typeof(FieldView), propertyChanged: static (bindable, oldValue, newValue) =>
        {
            var control = (FieldView)bindable;
            control.fieldDrawable.Cells = (Models.Cell[,])newValue;
            control.Invalidate();
        });

    public bool ShouldDrawShips
    {
        get => (bool)GetValue(ShouldDrawShipsProperty);
        set => SetValue(ShouldDrawShipsProperty, value);
    }

    public Models.Cell[,] Cells
    {
        get => (Models.Cell[,])GetValue(CellsProperty);
        set => SetValue(CellsProperty, value);
    }

    FieldDrawable fieldDrawable;

    public FieldView()
    {
        fieldDrawable = new FieldDrawable(this.ShouldDrawShips);
        this.Drawable = fieldDrawable;
    }
}