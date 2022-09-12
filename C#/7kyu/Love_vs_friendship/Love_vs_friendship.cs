using System;

//https://www.codewars.com/kata/59706036f6e5d1e22d000016

public static class Kata
{
  public static int WordsToMarks(string str)
  {
    int result = 0;
        string collection = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < str.Length; i++)
        {
            result += collection.IndexOf(str[i]) + 1;
        }
        return result;
  }
}