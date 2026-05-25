using System;

namespace lvl2
{
    public static class CombinatoricsMath
        { 
        public static double CalculateNumbersWithRepetition(int totalDigitsCount, bool hasZero, int numberLength)
        {
            if (numberLength <= 0) return 0;
            if (totalDigitsCount <= 0) return 0;
             
            int firstPositionOptions = hasZero ? (totalDigitsCount - 1) : totalDigitsCount;
             
            double remainingPositionsOptions = Math.Pow(totalDigitsCount, numberLength - 1);

            return firstPositionOptions * remainingPositionsOptions;
        }
    }
}