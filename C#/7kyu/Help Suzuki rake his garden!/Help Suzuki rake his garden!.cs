using System;
using System.Linq;

//https://www.codewars.com/kata/571c1e847beb0a8f8900153d

public class Kata
{
  public static string RakeGarden(string g)
  {
    return string.Join(" ", g.Split().Select(x => x == "rock" ? x : "gravel"));
  }
}