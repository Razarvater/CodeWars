using System;
using System.Linq;

//https://www.codewars.com/kata/5467e4d82edf8bbf40000155

public static class Kata
{
  public static int DescendingOrder(int num)
  {
    	int x = num;
        int countch = 0;
        int temp = 1;

        while (x != 0)
        {
            x /= 10;
            countch++;
            temp *= 10;
        };
       
        int[] arr = new int[countch];
        x = num;
        for (int i = 0; x!= 0; i++)
        {
            arr[i] = x%10;
            x /= 10;
        }

        var d =  arr.OrderBy(x=>-x);
        int n = 0;

        foreach (var item in d)
        {
            temp /= 10;
            n += item * temp;
        }
    return n;
  }
}