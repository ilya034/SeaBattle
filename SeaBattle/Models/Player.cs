namespace SeaBattle.Models;
public partial class Player : ObservableObject
{
    int _score;
    public int Score
    {
        set => _score = value;
        get => _score;
    }

    [ObservableProperty]
    public Field _field = new();

    public Player()
    {
        Field.CreateEmptyField();
    }
}