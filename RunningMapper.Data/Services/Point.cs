namespace RunningMapper.Data.Services
{
    public struct Point : IPoint
    {
        public double XPos { get; }
        public double YPos { get; }

        public Point(double xPos, double yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public IPoint ScaledBy(int scale)
        {
            return new Point(scale * XPos, scale * YPos);
        }
    }
}