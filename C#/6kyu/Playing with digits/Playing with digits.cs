using System;

//https://www.codewars.com/kata/5552101f47fc5178b1000050

public class DigPow 
{
  public static long digPow(int n, int p) 
  {
    long PreResult = 0;
    string helper = n.ToString();
        foreach(var item in helper)
          {
            PreResult+=(long)Math.Pow(int.Parse(item.ToString()),p++); 
          }
    if((float)PreResult/(float)n == Math.Floor((float)PreResult/(float)n)) return PreResult/(long)n;
  
    return -1;
  }
}