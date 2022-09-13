using System;
using System.Linq;

//https://www.codewars.com/kata/54b724efac3d5402db00065e

class MorseCodeDecoder
{
  public static string Decode(string morseCode)
  {
    return string.Concat(morseCode.Trim().Replace("   ", "  ").Split().Select(z => z == "" ? " " : MorseCode.Get(z)));
  }
}