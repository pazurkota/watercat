using CommunityToolkit.Maui.Views;
using watercat.Model;
using watercat.Pages.Popups;
using watercat.Services;
using watercat.ViewModel;

namespace watercat.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly IWaterNotificationService _notificationService;
    private readonly INotificationSchedulerService _notificationSchedulerService;

    private bool _notificationsEnabled;
    
    public SettingsPage(SettingsPageViewModel _viewModel,
        IWaterNotificationService notificationService,
        INotificationSchedulerService notificationSchedulerService)
    {
        InitializeComponent();
        
        BindingContext = _viewModel;
        _notificationService = notificationService;
        _notificationSchedulerService = notificationSchedulerService;
    }

    private void Entry_OnCompleted(object sender, EventArgs e)
    {
        if (sender is Entry entry && BindingContext is SettingsPageViewModel viewModel)
        {
            viewModel.SetNewWaterGoalCommand.Execute(int.Parse(entry.Text));
        }
    }

    private async void OnNotifyClicked(object sender, EventArgs e)
    {
        if (_notificationsEnabled)
        {
            await DisplayAlert("Notifications", "Notifications has been disabled!", "Dismiss");
            _notificationSchedulerService.StopNotifications();
            _notificationsEnabled = false;
        }
        else
        {
            await _notificationService.RequestPermissionAsync();
            await DisplayAlert("Notifications", "Notifications has been enabled!", "Dismiss");
            _notificationSchedulerService.StartPeriodicNotifications(3, 9, 21);
            _notificationsEnabled = true;
        }
    }
}