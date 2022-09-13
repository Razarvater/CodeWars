//https://www.codewars.com/kata/514b92a657cdc65150000006

public static class Kata
{
  public static int Solution(int value)
  {
    int Result = 0;
    for(int i = 0; i<value;i++)
      if(i%3 == 0 || i%5 == 0)
          Result+=i;

    return Result;
  }
}