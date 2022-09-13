using System;

//https://www.codewars.com/kata/55caef80d691f65cb6000040

public class Kata
{
  public static string GeometricSequenceElements(int a, int r, int n)
  {
    string Result = string.Empty;
    for(int i = 0;i<n;i++)
      {
        if(i!=0)Result+=", ";
        Result+=$"{a}";
        a*=r;
      }
      return Result;
  }
}