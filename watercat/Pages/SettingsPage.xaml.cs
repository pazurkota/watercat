using System;
using Microsoft.Maui.Controls;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel _viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    private void Entry_OnCompleted(object sender, EventArgs e)
    {
        if (sender is Entry entry && BindingContext is SettingsPageViewModel viewModel)
        {
            viewModel.SetNewWaterGoalCommand.Execute(int.Parse(entry.Text));
        }
    }
}