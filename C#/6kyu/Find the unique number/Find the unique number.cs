using System.Collections.Generic;
using System.Linq;

//https://www.codewars.com/kata/585d7d5adb20cf33cb000235

public class Kata
{
  public static int GetUnique(IEnumerable<int> numbers)
  {
    return numbers.GroupBy(x=>x).Single(s=> s.Count() == 1).Key;
  }
}