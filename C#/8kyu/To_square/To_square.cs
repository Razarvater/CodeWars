using System;
using System.Linq;

//https://www.codewars.com/kata/57f6ad55cca6e045d2000627

public class Kata
{
  public static int[] SquareOrSquareRoot(int[] array)
  {
    return array.Select(x => (int)(Math.Sqrt(x) % 1 == 0 ? Math.Sqrt(x) : x * x)).ToArray();
  }
}