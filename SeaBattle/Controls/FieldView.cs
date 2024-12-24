using SeaBattle.Drawables;
using SeaBattle.Models;

namespace SeaBattle.Controls;

public partial class FieldView : GraphicsView
{
    public static BindableProperty FieldProperty = BindableProperty.Create(nameof(Field),
        typeof(Models.Cell[,]), typeof(FieldView), propertyChanged: static (bindable, oldValue, newValue) =>
        {
            var control = (FieldView)bindable;
            control.fieldDrawable.Field = (Models.Cell[,])newValue;
            control.Invalidate();
        });

    public Models.Cell[,] Field
    {
        get => GetValue(FieldProperty) as Models.Cell[,];
        set => SetValue(FieldProperty, value);
    }

    FieldDrawable fieldDrawable;
    public FieldView()
    {
        fieldDrawable = new FieldDrawable();
        this.Drawable = fieldDrawable;
    }
}