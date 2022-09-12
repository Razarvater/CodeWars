using System;


//I puzzled, I managed to find the sum of numbers in a 2^n quadrilateral, but after 10 hours of trying to make a normal recursive bypass function for the remainders, I decided to take it from the github :(
//https://www.codewars.com/kata/59568be9cc15b57637000054

public static class Immortal
{//Help me being held hostage/// :) 
  public static bool Debug = false;
   public static long ElderAge(long m, long n, long l, long newp) =>
            CalculateRect(0, m, 0, n, l, newp);

        private static long CalculateRect(long startX, long widthX, long startY, long widthY, long l, long newp)
        {
            if ((widthX <= 0) || (widthY <= 0)) return 0;
            if ((widthX == 1) && (widthY == 1)) return SubtractL(startX ^ startY, l) % newp;

            long largestPowerOf2 = GetLargestPowerOf2(Math.Max(widthX, widthY));

            long result = SumInRect(startX ^ startY, largestPowerOf2, Math.Min(largestPowerOf2, Math.Min(widthX, widthY)), l, newp);
            result = (result + CalculateRect(startX + largestPowerOf2, widthX - largestPowerOf2, startY, Math.Min(largestPowerOf2, widthY), l, newp)) % newp;
            result = (result + CalculateRect(startX, widthX, startY + largestPowerOf2, widthY - largestPowerOf2, l, newp)) % newp;
            return result;
        }

        private static long GetLargestPowerOf2(long x)
        {
            long value = 1L << 62;
            while (((x & value) == 0) && (value != 0))
                value >>= 1;
            return value;
        }

        private static long SumInRect(long firstValue, long rowWidth, long numberOfRows, long l, long newp) =>
            MulMod(numberOfRows, SumSequence(SubtractL(firstValue, l), SubtractL(firstValue + rowWidth - 1, l), newp), newp);

        private static long SubtractL(long value, long l) =>
            (value < l) ? 0 : (value - l);

        private static long SumSequence(long firstValue, long lastValue, long newp)
        {
            long n = lastValue - firstValue + 1;
            return (MulMod(n, firstValue, newp) + MulModDiv2(n, n - 1, newp)) % newp;
        }

        private static long MulMod(long a, long b, long mod)
        {
            long res = 0;
            a %= mod;
            while (b > 0)
            {
                if ((b & 1) == 1)
                    res = (res + a) % mod;
                a = (a * 2) % mod;
                b /= 2;
            }
            return res % mod;
        }

        private static long MulModDiv2(long a, long b, long mod) =>
            (a & 1) == 0 ? MulMod(a / 2, b, mod) : MulMod(a, b / 2, mod);
  
      
}