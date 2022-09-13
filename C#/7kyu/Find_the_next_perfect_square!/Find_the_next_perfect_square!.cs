using System;

//https://www.codewars.com/kata/56269eb78ad2e4ced1000013

public class Kata
{
  public static long FindNextSquare(long num)
  {
    double numstartMin = Math.Sqrt((double)num);
    if(numstartMin % 1 != 0 ) return -1;
    long result= 0;
    for(long i = num+1; i<i+2;i++)
      {
        if(Math.Sqrt(i)%1 ==0)
        {
          result = i;
          break;
        }
      } 
    return result;
  }
}