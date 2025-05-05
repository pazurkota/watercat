namespace watercat.Model;

public interface INotificationSchedulerService
{
    void StartPeriodicNotifications(int hours, int startHour, int endHour);
    void StopNotifications();
}