using System;
using System.Collections;
using System.Collections.Generic;

namespace RunningMapper.Data.Services
{
    internal class PointDistributor : IPointDistributor
    {
        Func<int, IPoint> distribution; // do I need this?
        private int index;
        private int length;
        private int scale;

        public IPoint CurrentPoint { get; private set; }

        public object Current => CurrentPoint;

        IPoint IEnumerator<IPoint>.Current => CurrentPoint;

        class Algorithm
        {
            static Func<int, IPoint>[] list = new Func<int, IPoint>[]
                {
                    x => LinearDistribution(x),
                    x => LinearDistribution(x, gradient: 0, intercept: 1),
                    x => QuadraticDistribution(x)
                };

            internal static Func<int, IPoint> Get(int seed) => list[seed % list.Length];

            private static Point LinearDistribution(int x, double gradient = 1, double intercept = 0, double increment = 1)
            {
                return LinearDistribution(increment * x, gradient, intercept);
            }

            private static Point LinearDistribution(double x, double gradient = 1, double intercept = 0)
            {
                var y = gradient * x + intercept;
                return new Point(x, y);
            }

            private static Point QuadraticDistribution(int x)
            {
                return new Point(x, Math.Pow(x, 2));
            }
        }

        public bool MoveNext()
        {
            if (index < length)
            {
                CurrentPoint = distribution(index).ScaledBy(scale);
                index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
        }

        public void Dispose()
        {
        }

        internal PointDistributor(int seed, int length, int scale = 1)
        {
            distribution += Algorithm.Get(seed);
            this.length = length;
            this.scale = scale;
        }
    }
}