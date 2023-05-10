using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP.Classes
{
    public class PlotPoint
    {
        public PlotPoint(double x = 0d, double y = 0d)
        {
            X = x; Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double Distance(PlotPoint other)
        {
            double x = other.X - X;
            double y = other.Y - Y;
            return Math.Sqrt(x*x + y*y);
        }

        public override string ToString()
        {
            return $"({X.ToString("0.##")},{Y.ToString("0.##")})";
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is PlotPoint)) return false;

            PlotPoint other = obj as PlotPoint;

            return other.X == X && other.Y == Y ;
        }
    }
}
