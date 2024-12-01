using System;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using watercat.ViewModel;

namespace watercat.Pages.Popups;

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