using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrthodromicDistanceCalculator
{
    public static class Helpers
    {
        public static double Sin2(double x)
        {
            return 0.5 - 0.5 * Math.Cos(2 * x);
        }

        public static double Diff(double a, double b)
        {
            return Math.Abs(b - a);
        }
    }
}
