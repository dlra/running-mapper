using System.Collections.Generic;

namespace RunningMapper.Data.Services
{
    public interface IMapping
    {
        IEnumerable<IPoint> RoutePoints { get; }
        IEnumerable<IPoint> AddPoint(IPoint point);
    }
}