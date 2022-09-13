using System;

//https://www.codewars.com/kata/534ea96ebb17181947000ada

public class Kata 
{
  public static int BreakChocolate(int n, int m) 
  {
    if(n == 0 || m == 0) return 0;
    return n-1+(m-1) * n;
  }
}