using System;
using System.Collections.Generic;

//https://www.codewars.com/kata/5259acb16021e9d8a60010af

public static class Kata
{
  public static int Lcm(List<int> nums)
  {
    List<int> nums2 = new List<int>();
    nums2 = nums.GetRange(0,nums.Count);
    
    if(nums2.Count == 0) return 1;
    if(Array.IndexOf(nums2.ToArray(),0) != -1) return 0;
        
    for(int i = 0; i<nums2.Count - 1;i++)
      {
          nums2[i+1] = NOK(nums2[i],nums2[i+1]);
      }
    return nums2[nums2.Count - 1];
  }

   public static int NOD(int a,int b)
     {
       while (a != b) 
       {
          if (a>b) 
            a -= b;
          else 
            b -= a;
       }
     return a;
    }
  public static int NOK(int a, int b) => (a * b)/NOD(a,b);

}