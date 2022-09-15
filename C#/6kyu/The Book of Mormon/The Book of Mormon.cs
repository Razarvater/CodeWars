//https://www.codewars.com/kata/58373ba351e3b615de0001c3
//

public class Kata
{
  private static int MaxIter = 100;
  public static long Mormons(long startingNumber, long reach, long target)
  {
    if(startingNumber>=target)return 0;
    for(int i = 1;i<MaxIter;i++)
      {
          startingNumber += startingNumber*reach;
        if(startingNumber>=target)return i;
      }
    return 0;
  }
}