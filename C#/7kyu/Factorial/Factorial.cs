using System;

//https://www.codewars.com/kata/57a049e253ba33ac5e000212

namespace Solution
{
  public static class Program
  {
    public static int factorial(int n)
    {
      int Result = 1;
      for(int i =1;i<=n;Result *=i++);
        
      return Result;
    }
  }
}