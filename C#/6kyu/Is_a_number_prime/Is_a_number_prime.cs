//https://www.codewars.com/kata/5262119038c0985a5b00029f

public static class Kata
{
  public static bool IsPrime(int n)
  {
    if(n<=1)return false;
    for(int i = 2;i<=System.Math.Sqrt(n);i++)
      {
        if(n%i==0)return false;
      }
      return true;
  }
}