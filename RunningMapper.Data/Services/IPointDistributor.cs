using System.Collections.Generic;

namespace RunningMapper.Data.Services
{
    public interface IPointDistributor : IEnumerator<IPoint>
    {
        IPoint CurrentPoint { get; }
    }
}