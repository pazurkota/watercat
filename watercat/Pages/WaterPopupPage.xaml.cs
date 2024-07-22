using CommunityToolkit.Maui.Views;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class WaterPopupPage : Popup
{
    public WaterPopupPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        var closeAction = new Action(ClosePopup);
        BindingContext = new WaterPopupPageViewModel(viewModel, closeAction);
    }

    private void ClosePopup()
    {
        Close();
    }

    private void Entry_OnCompleted(object sender, EventArgs e)
    {
        if (sender is Entry entry && BindingContext is WaterPopupPageViewModel viewModel)
        {
            viewModel.AddWaterCommand.Execute(entry.Text);
        }
    }
}