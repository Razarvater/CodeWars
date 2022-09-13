using System;
using System.Collections.Generic;
using System.Linq;

//https://www.codewars.com/kata/57f222ce69e09c3630000212

public class Kata
{
  public static string Well(string[] x)
  {
    
    int countIdeas = 0;
    for(int i = 0;i<x.Count();i++)
      { 
        Console.Write(x[i] +"|");
        if(x[i]=="good")countIdeas++;
        if(countIdeas > 2)return"I smell a series!";
      }
    if(countIdeas > 0)return"Publish!";
    return "Fail!";
  }
}