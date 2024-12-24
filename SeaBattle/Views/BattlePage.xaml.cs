namespace SeaBattle.Views;

public partial class BattlePage : ContentPage
{
	BattleViewModel viewModel;

	public BattlePage(BattleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		viewModel.HandleTap(e.GetPosition(Player2FieldGraphicsView).Value);
		Player1FieldGraphicsView.Invalidate();
		Player2FieldGraphicsView.Invalidate();
    }
}
