using Microsoft.Maui.Controls;

namespace watercat;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}