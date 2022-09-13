//https://www.codewars.com/kata/55a5c82cd8e9baa49000004c

public class Kata
{
  public static long DivisibleCount(long x, long y, long k)
  {
    return x % k == 0 ? y/k - x/k + 1 : y/k - x/k;
  }
}