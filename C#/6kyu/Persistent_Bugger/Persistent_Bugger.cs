using System;

//https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec

public class Persist 
{
  public static int Persistence(long n) 
  {
    long temp = n;
    long Result = 1;
    int Counter = 0;
    while(temp>=10)
    {
     while(temp!=0)
       {
          
          Result*=temp%10;
          temp/=10;
        };
      
      Counter++;
      temp = Result;
      Result = 1;
      
    };
    
    return Counter;
  }
}