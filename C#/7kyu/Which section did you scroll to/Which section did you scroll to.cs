using System;

//https://www.codewars.com/kata/5cb05eee03c3ff002153d4ef

public class Kata {
  public static int GetSectionId(int n, int[] a)
  {
    int Sum = -1;
    for(int i = 0;i<a.Length;i++)
      {
        Sum+=a[i];
        if(n<=Sum)return i;
      }
    return -1;
  }
}