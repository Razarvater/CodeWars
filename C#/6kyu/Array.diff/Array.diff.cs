using System;
using System.Collections.Generic;

//https://www.codewars.com/kata/523f5d21c841566fde000009

public class Kata
{
  public static int[] ArrayDiff(int[] a, int[] b)
  {
    List<int> Result = new List<int>();
    foreach(var item in a)
        if(Array.IndexOf(b,item)==-1)Result.Add(item);
    
    return Result.ToArray();
  }
}