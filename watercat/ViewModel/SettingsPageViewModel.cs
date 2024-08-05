namespace watercat.ViewModel;

public class SettingsPageViewModel
{
    private readonly MainPageViewModel _viewModel;
    
    public SettingsPageViewModel(MainPageViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public SettingsPageViewModel()
    {
    }
}