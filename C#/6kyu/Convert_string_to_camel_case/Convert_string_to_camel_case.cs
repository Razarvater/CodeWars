using System;

//https://www.codewars.com/kata/517abf86da9663f1d2000003

public class Kata
{
  public static string ToCamelCase(string str)
  {
    string collectionA="abcdefghijklmnopqrstuvwxyz";
    string collectionB="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    string Result = "";
    bool isReg = false;
    foreach(var item in str)
      {
      if(isReg && collectionA.IndexOf(item) != -1)
        {
          Result += collectionB[collectionA.IndexOf(item)];
          isReg = !isReg;
        }
        else if(item is '-'or '_')
          isReg = !isReg;
        else
          {
            isReg = false;
            Result += item;
          }
      }
    return Result;
  }
}