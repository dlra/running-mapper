using RunningMapper.Data.Models;

namespace RunningMapper.Data.Services
{
    internal interface IRouteGenerator
    {
        IPointDistributor GetPointDistributor(int seed);
    }
}