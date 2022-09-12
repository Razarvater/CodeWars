using System;
using System.Linq;

//https://www.codewars.com/kata/58ad317d1541651a740000c5

namespace myjinxin
{
    public class Kata
    {
     public string MiddlePermutation(string s)
        {
            s = new string(s.OrderByDescending(c => c).ToArray());
            int midLength = 1 + s.Length % 2;
            return s.Substring(s.Length / 2, midLength) + s.Remove(s.Length / 2, midLength);
        }
    } 
}