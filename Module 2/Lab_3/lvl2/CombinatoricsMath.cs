using System;

namespace lvl2
{
    public static class CombinatoricsMath
    {
        public static double CalculateNumbersWithRepetition(int totalDigitsCount, bool hasZero, int numberLength)
        { 
            if (numberLength <= 0 || totalDigitsCount <= 0)
            {
                return 0;
            }
             
            int firstPositionOptions;
            if (hasZero == true)
            { 
                firstPositionOptions = totalDigitsCount - 1;
            }
            else
            { 
                firstPositionOptions = totalDigitsCount;
            }
             
            int remainingPositionsCount = numberLength - 1;
             
            double remainingPositionsOptions = Math.Pow(totalDigitsCount, remainingPositionsCount);
             
            return firstPositionOptions * remainingPositionsOptions;
        }
    }
}