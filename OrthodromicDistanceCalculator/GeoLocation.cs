using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrthodromicDistanceCalculator
{
    public class GeoLocation
    {
        #region Properties

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public double LongitudeRad { get { return DegreeToRadian(Longitude); } }
        public double LatitudeRad { get { return DegreeToRadian(Latitude); } }

        #endregion

        #region Helper Functions

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        #endregion
    }
}
