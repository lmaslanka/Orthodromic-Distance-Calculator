using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using OrthodromicDistanceCalculator;

namespace OrthodromicDistanceCalculator.Tests
{
    public class OrthodromicDistanceCalculatorTests
    {
        [Fact]
        public void OrthodromicDistance_CoordinatesVeryCloseTogether_ReturnsDistanceBetween38kmAnd39km()
        {
            OrthodromicDistanceCalculator calculator = new OrthodromicDistanceCalculator();

            // Distance Calculated is 38.5 km
            double expectedDistanceLowerBound = 38.0;
            double expectedDistanceUpperBound = 39.0;

            double distance = calculator.OrthodromicDistance(new GeoLocation() { Latitude = 43.372991, Longitude = -80.985739 }, new GeoLocation() { Latitude = 43.553447, Longitude = -81.393328 }, OrthodromicDistanceCalculator.FormulaType.HaversineFormula);

            Assert.True((expectedDistanceLowerBound <= distance) && (distance <= expectedDistanceUpperBound), string.Format("Distance did not fall within expected range of {0} km <= x <= {1} km, the distance was {2} km", expectedDistanceLowerBound, expectedDistanceUpperBound, distance)); 
        }

        [Fact]
        public void OrthodromicDistance_CoordinatesVeryFarApart_ReturnsDistanceBetween2886kmAnd2887km()
        {
            OrthodromicDistanceCalculator calculator = new OrthodromicDistanceCalculator();

            // Distance Calculated is 2886.45 km
            double expectedDistanceLowerBound = 2886.0;
            double expectedDistanceUpperBound = 2887.0;

            double distance = calculator.OrthodromicDistance(new GeoLocation() { Latitude = 36.12, Longitude = -86.67 }, new GeoLocation() { Latitude = 33.94, Longitude = -118.40 }, OrthodromicDistanceCalculator.FormulaType.HaversineFormula);

            Assert.True((expectedDistanceLowerBound <= distance) && (distance <= expectedDistanceUpperBound), string.Format("Distance did not fall within expected range of {0} km <= x <= {1} km, the distance was {2} km", expectedDistanceLowerBound, expectedDistanceUpperBound, distance));
        }
    }
}
