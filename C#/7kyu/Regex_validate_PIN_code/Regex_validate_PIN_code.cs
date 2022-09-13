using System;
using System.Text.RegularExpressions;
using System.Linq;
//I solved it without Regex because I didn't know how to use regular expressions back then, but now I don't really know them either.
//https://www.codewars.com/kata/55f8a9c06c018a0d6e000132

public class Kata
{
  public static bool ValidatePin(string pin)
  {
    bool Result = true;
        int temp;
    
        if(pin == String.Empty || pin[0] is '+' or '-' or ' ' or '\n' || pin[pin.Length-1] is '+' or '-' or ' ' or '\n')
            return false;
        
    
        if (pin.Length == 4 || pin.Length == 6)
        {
            Result = Result && true;
        }
        else
        {
            Result = Result && false;
        }
    
    Result = Result && (int.TryParse(pin, out temp));
    return Result;
  }
}