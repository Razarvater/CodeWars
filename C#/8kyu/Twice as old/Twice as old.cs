using System;

//https://www.codewars.com/kata/5b853229cfde412a470000d0

namespace Solution
{
  public class TwiceAsOldSolution
  {
    public static int TwiceAsOld(int dadYears, int sonYears)
    {
        return dadYears-2*sonYears < 0 ? -(dadYears-2*sonYears) : dadYears-2*sonYears;
    }
  }
}