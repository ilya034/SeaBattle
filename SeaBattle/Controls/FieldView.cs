using SeaBattle.Drawables;
using SeaBattle.Models;

namespace SeaBattle.Controls;

public partial class FieldView : GraphicsView
{
    public static BindableProperty CellsProperty = BindableProperty.Create(nameof(Field),
        typeof(Models.Cell[,]), typeof(FieldView), propertyChanged: static (bindable, oldValue, newValue) =>
        {
            var control = (FieldView)bindable;
            control.fieldDrawable.Cells = (Models.Cell[,])newValue;
            control.Invalidate();
        });

    public Models.Cell[,] Cells
    {
        get => GetValue(CellsProperty) as Models.Cell[,];
        set => SetValue(CellsProperty, value);
    }

    FieldDrawable fieldDrawable;
    public FieldView()
    {
        fieldDrawable = new FieldDrawable();
        this.Drawable = fieldDrawable;
    }
}