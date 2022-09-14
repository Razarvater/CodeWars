//It was possible through LINQ, but is it really so interesting?
//https://www.codewars.com/kata/52597aa56021e91c93000cb0

public class Kata
{
  public static int MaxNullCount = 100;
  public static int[] MoveZeroes(int[] arr)
  {
    for(int z = 0;z<MaxNullCount;z++)
      {
        for(int i = 0; i<arr.Length;i++)
            if(arr[i]==0)
              for(int j = i;j<arr.Length - 1;j++)
                {
                  arr[j]^=arr[j + 1];
                  arr[j + 1]^=arr[j];
                  arr[j]^=arr[j + 1];
                }
      }
      return arr;            
  }
}