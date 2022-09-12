using System;
using System.Linq;

//https://www.codewars.com/kata/59b7571bbf10a48c75000070

public static class Kata
{
  public static string Tops(string msg)
  {
    string Result = string.Empty;
    if(msg == string.Empty)return msg;
    int i = 1;
    int j = 1;
    while(true)
      {
      try
        {
          Result+=msg[j];
            i+=4;
            j+=i;
        }
      catch(IndexOutOfRangeException)
        {
          break;
        };
      }
    

    return new string(Result.ToCharArray().Reverse().ToArray());
  }
}