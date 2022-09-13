using System;

//https://www.codewars.com/kata/5513795bd3fafb56c200049e

public static class Kata
{
  public static int[] CountBy(int x, int n)
  {
    int[] z = new int[n];
    
      for(int i = 0;i<n;i++)
        {
           z[i]=(i+1)*x;
        };
    return z;
  }
}