using System;

//https://www.codewars.com/kata/545cedaa9943f7fe7b000048

public static class Kata
{
  public static bool IsPangram(string str)
  {
    string collection = "abcdefghijklmnopqrstuvwxyz";
    
    int i = 0;
    foreach(var item in str)
      {
        if(!char.IsLetter(item))
          str = str.Replace(item , ' ');
          i++;
      }
    str = str.Replace(" ", string.Empty).ToLower();
    bool Result = true;
    foreach(var item in collection)
        Result = Result && str.Contains(item);
    
    return Result;
  }
}