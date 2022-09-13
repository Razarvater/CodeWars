//https://www.codewars.com/kata/57f780909f7e8e3183000078

public class Kata
{
  public static int Grow(int[] x)
  {
    int Result = 1;
    
    foreach(int item in x)
      Result*=item;
    
      return Result;
  }
}