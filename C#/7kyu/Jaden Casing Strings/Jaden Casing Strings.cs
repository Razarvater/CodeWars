using System;

//https://www.codewars.com/kata/5390bac347d09b7da40006f6

public static class JadenCase
{
  public static string ToJadenCase(this string phrase)
  {
    string Result = string.Empty;
    bool temp = true;
    foreach(var item in phrase)
      {
        if(item == ' ')
        {
          temp = true;
          Result+=item;
          continue;
        }
      
        if(temp)
          {
            Result+=item.ToString().ToUpper();
            temp = false;
          }
        else
          Result+=item;
      }
    return Result;
  }
}