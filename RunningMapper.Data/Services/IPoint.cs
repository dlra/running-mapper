namespace RunningMapper.Data.Services
{
    public interface IPoint
    {
        double XPos { get; }
        double YPos { get; }

        IPoint ScaledBy(int scale);
    }
}