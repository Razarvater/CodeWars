using System.Linq;
using System.Collections.Generic;

//https://www.codewars.com/kata/55c4eb777e07c13528000021

public class FactorialTail {
  public static int zeroes (int b, int n) {
    var fact = Factorize(b);
    return fact.Distinct().Select(e=>(int) ( GetZ(e,n)/ fact.Count(s=> s==e)) ).Min();
  }
  
  private static int[] Factorize(int n) {
    List<int> res= new List<int>();
    for (int i=2; n > 1; i++)
    while (n% i ==0 )  {
      res.Add(i);
      n = n/i;
    }
    return res.ToArray();
  }
  
  private static int GetZ(int b, int n) {
    int i =b, j=b, t=0, sum=0;
    do {
     t = (int)(n / i); 
     sum += t;  
     i *= j; 
    } while (t!=0);
    return sum;
  }
}