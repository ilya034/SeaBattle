using SeaBattle.Drawables;

namespace SeaBattle.Views;

public partial class BattlePage : ContentPage
{
	public BattlePage(BattleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
