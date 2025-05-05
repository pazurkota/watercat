namespace watercat.Model;

public interface IWaterProgressTrackService
{
    double GetProgressPercent();
    double GetRemaining();
}