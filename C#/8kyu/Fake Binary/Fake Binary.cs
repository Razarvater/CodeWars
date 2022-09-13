using System.Text.RegularExpressions;

//https://www.codewars.com/kata/57eae65a4321032ce000002d

public class Kata
{
  public static string FakeBin(string x)
  {
    x = Regex.Replace(x,"[1-4]","0");
    x = Regex.Replace(x,"[5-9]","1");
    return x;
  }
}