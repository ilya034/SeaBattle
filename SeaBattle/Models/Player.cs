namespace SeaBattle.Models;
public partial class Player : ObservableObject
{
    public int Score;
    [ObservableProperty]
    public Field _field = Field.CreateEmptyField();
}