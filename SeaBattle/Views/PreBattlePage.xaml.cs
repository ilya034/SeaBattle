namespace SeaBattle.Views;

public partial class PreBattlePage : ContentPage
{
	public PreBattlePage(PreBattleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
