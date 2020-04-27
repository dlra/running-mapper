using System.Collections.Generic;
using System.Collections;

namespace RunningMapper.Data.Services
{
    internal class RouteGenerator : IEnumerable<IPoint>
        {
            int seed, length, scale;

        internal RouteGenerator(int seed, int length, int scale)
            {
                this.seed = seed;
                this.length = length;
                this.scale = scale;
        }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<IPoint> GetEnumerator()
            {
                return GetPointDistributor();
            }

            IPointDistributor GetPointDistributor()
            {
                return new PointDistributor(seed, length, scale);
            }
        }
}
