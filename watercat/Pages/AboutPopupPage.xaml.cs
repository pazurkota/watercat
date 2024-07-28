using CommunityToolkit.Maui.Views;

namespace watercat.Pages;

public partial class AboutPopupPage : Popup
{
    private const string GithubPageUri = "https://github.com/pazurkota/watercat";
    private const string WebsiteUri = "https://pazurkota.me/";
    
    public AboutPopupPage()
    {
        InitializeComponent();
        AppVersionLabel.Text = $"App version: v{VersionTracking.CurrentVersion}";
    }

    private async void GithubRepoButton_OnClicked(object sender, EventArgs e)
    {
        Uri uri = new(GithubPageUri);
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private async void WebsiteButton_OnClicked(object sender, EventArgs e)
    {
        Uri uri = new(WebsiteUri);
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}