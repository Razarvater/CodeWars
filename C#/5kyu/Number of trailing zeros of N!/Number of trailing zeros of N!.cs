using System;

//https://www.codewars.com/kata/52f787eb172a8b4ae1000a34

public static class Kata 
{
  public static int TrailingZeros(int n)
  {
    int Result = 0;//comment
    while(n>0)
      {
        n/=5;
        Result+=n;
      }
    return Result;
  }
}