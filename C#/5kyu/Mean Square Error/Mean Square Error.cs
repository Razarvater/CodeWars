using System;

//agree, awarded
//https://www.codewars.com/kata/51edd51599a189fe7f000015

public class Kata
{
  public static double Solution(int[] firstArray, int[] secondArray)
  {
    double Sum = 0;
    for(int i = 0;i<firstArray.Length;i++)
      {
          Sum+=Math.Pow(Math.Abs(Math.Max(firstArray[i],secondArray[i]) - Math.Min(firstArray[i],secondArray[i])) , 2);
      }
    return Sum/firstArray.Length;
  }
}