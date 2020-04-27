using System;
using System.Collections.Generic;
using RunningMapper.Data.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMapper.Data.Models
{
    public class Run : IMapping
    {
        List<IPoint> routePoints;

        public Run()
        {
            routePoints = new List<IPoint>();
        }

        public int Id { get; set; }
        public IEnumerable<IPoint> RoutePoints => routePoints;

        public IEnumerable<IPoint> AddPoint(IPoint point)
        {
            routePoints?.Add(point);
            
            return routePoints;
        }

        public struct RoutePoint : IPoint
        {
            internal RoutePoint(double xPos, double yPos)
            {
                XPos = xPos;
                YPos = yPos;
            }

            public double XPos { get; }

            public double YPos { get; }

            public IPoint ScaledBy(int scale)
            {
                return new RoutePoint(scale * XPos, scale * YPos);
            }
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            routePoints.ForEach(p => str.Append($"({p.XPos}, {p.YPos}), "));
            str.Remove(str.Length - 2, 2);

            return str.ToString();
        }
    }
}
