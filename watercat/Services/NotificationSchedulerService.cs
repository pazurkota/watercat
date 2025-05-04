using watercat.Model;
using Plugin.LocalNotification;

namespace watercat.Services;

public class NotificationSchedulerService(IWaterService waterService, IWaterNotificationService notificationService) : INotificationSchedulerService
{
    private Timer _timer;
    
    public void StartPeriodicNotifications(int hours = 3, int startHour = 9, int endHour = 21)
    {
        for (int hour = startHour; hour <= endHour; hour += hours)
        {
            var notifyTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Hour, hour, 0, 0);

            // set to next day if time is up
            if (notifyTime <= DateTime.Now)
               notifyTime = notifyTime.AddDays(1);
            
            notificationService.SendWaterProgressNotification();
        }
    }

    public void StopNotifications()
    {
        LocalNotificationCenter.Current.CancelAll();
    }
}