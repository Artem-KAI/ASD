using System;

namespace lvl1
{
    public static class Combinatorics
    { 
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факторіал від'ємного числа не існує.");

            if (n == 0 || n == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}