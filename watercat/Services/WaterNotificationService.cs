using watercat.Model;
using Plugin.LocalNotification;


namespace watercat.Services;

public class WaterNotificationService : IWaterNotificationService
{
    public async Task RequestPermissionAsync()
    {
        await LocalNotificationCenter.Current.RequestNotificationPermission();
    }

    public void SendNotification(string title, string msg, int id = 100)
    {
        NotificationRequest request = new()
        {
            NotificationId = id,
            Title = title,
            Description = msg,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5)
            }
        };

        LocalNotificationCenter.Current.Show(request);
    }

    public void SendWaterProgressNotification(double percent, double remaining)
    {
        string message;

        switch (percent)
        {
            case >= 100:
                message =  "🎉 You reached your goal! Great work!";
                break;
            case >= 75:
                message = $"🚰 You reached {percent:F0}% of your goal! Only {remaining} ml remains!";
                break;
            case >= 50:
                message = $"💧 Half of your daily goal is behind you! ({percent:F0}%) – {remaining} ml remains.";
                break;
            default:
                message = $"🔔 Time to drink water! You just reached {percent:F0}% – {remaining} ml remains.";
                break;
        }
        
        SendNotification("Your progress", message);
    }
}