namespace SeaBattle.Services;

public class ViewModelLocator
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public BattleViewModel BattleViewModel => _serviceProvider.GetRequiredService<BattleViewModel>();
    public PreBattleViewModel PreBattleViewModel => _serviceProvider.GetRequiredService<PreBattleViewModel>();
}