namespace watercat.Model;

public interface IWaterNotificationService
{
    Task RequestPermissionAsync();
    void SendNotification(string title, string msg, int id = 100);
    void SendWaterProgressNotification(double percent, int remaining);
}