using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrthodromicDistanceCalculator
{
    public class OrthodromicDistanceCalculator
    {
        public const double c_AverageRadiusForSphericalApproximationOfEarth = 6371.01;

        public enum FormulaType
        {
            SphericalLawOfCosinesFormula = 1,
            HaversineFormula = 2,
            VincentyFormula = 3
        };

        public double OrthodromicDistance(GeoLocation locationA, GeoLocation locationB, FormulaType formula)
        {
            return (c_AverageRadiusForSphericalApproximationOfEarth * ArcLength(locationA, locationB, formula));
        }

        private double ArcLength(GeoLocation locationA, GeoLocation locationB, FormulaType formula)
        {
            switch (formula)
            {
                case FormulaType.SphericalLawOfCosinesFormula:
                    return ArcLengthSphericalLawOfCosines(locationA, locationB);

                case FormulaType.HaversineFormula:
                    return ArcLengthHaversineFormula(locationA, locationB);

                case FormulaType.VincentyFormula:
                    return ArcLengthVincentyFormula(locationA, locationB);

                default:
                    return 0;
            }
        }

        private double ArcLengthSphericalLawOfCosines(GeoLocation locationA, GeoLocation locationB)
        {
            return Math.Acos((Math.Sin(locationA.LatitudeRad) * Math.Sin(locationB.LatitudeRad)) + (Math.Sin(locationA.LatitudeRad) * Math.Sin(locationB.LatitudeRad) * Math.Cos(Helpers.Diff(locationA.LongitudeRad, locationB.LongitudeRad))));
        }

        private double ArcLengthHaversineFormula(GeoLocation locationA, GeoLocation locationB)
        {
            return 2 * Math.Asin(Math.Sqrt((Helpers.Sin2(Helpers.Diff(locationA.LatitudeRad, locationB.LatitudeRad) / 2)) + (Math.Cos(locationA.LatitudeRad) * Math.Cos(locationB.LatitudeRad) * Helpers.Sin2(Helpers.Diff(locationA.LongitudeRad, locationB.LongitudeRad) / 2))));
        }

        private double ArcLengthVincentyFormula(GeoLocation locationA, GeoLocation locationB)
        {
            return Math.Atan(Math.Sqrt(((Math.Pow(Math.Cos(locationB.LatitudeRad) * Math.Sin(Helpers.Diff(locationA.LongitudeRad, locationB.LongitudeRad)), 2)) + (Math.Pow((Math.Cos(locationA.LatitudeRad) * Math.Sin(locationB.LatitudeRad)) - (Math.Sin(locationA.LatitudeRad) * Math.Cos(locationB.LatitudeRad) * Math.Cos(Helpers.Diff(locationA.LongitudeRad, locationB.LongitudeRad))), 2))) / ((Math.Sin(locationA.LatitudeRad) * Math.Sin(locationB.LatitudeRad)) + (Math.Cos(locationA.LatitudeRad) * Math.Cos(locationB.LatitudeRad) * Math.Cos(Helpers.Diff(locationA.LongitudeRad, locationB.LongitudeRad))))));
        }
    }
}
