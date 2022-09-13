//https://www.codewars.com/kata/541c8630095125aba6000c00

public class Number
{
  public int DigitalRoot(long n)
  {
    System.Console.WriteLine(n);
    return (int)Rec(n);
  }
  public long Rec(long n)
    {
      long Result = 0;
    
    while(n!=0)
      {
        Result+=n%10;
        n/=10;
      }
    if(Result>9)
      Result = Rec(Result);
    
    return Result;
    }
}