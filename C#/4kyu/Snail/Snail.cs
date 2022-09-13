using System;
using System.Collections.Generic;

//https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1

public class SnailSolution
{
   public static int[] Snail(int[][] array)
   {
      int left = 0;
      int right = array[0].Length - 1;
      int top = 0;
      int bottom = array.Length - 1;

      List<int> result = new List<int>();
      while (true) 
      {
          if (left > right)
          {
              return result.ToArray();
          }

          if (left == right)
          {
              for (int i = top; i <= bottom; i++)
                  result.Add(array[i][right]);

              return result.ToArray();
          }

          for (int i = left; i < right; i++)
              result.Add(array[top][i]);

          for (int i = top; i < bottom; i++)
              result.Add(array[i][right]);

          for (int i = right; i > left; i--)
              result.Add(array[bottom][i]);

          for (int i = bottom; i > top; i--)
              result.Add(array[i][left]);

          left++;
          right--;
          top++;
          bottom--;
      }
   }
}