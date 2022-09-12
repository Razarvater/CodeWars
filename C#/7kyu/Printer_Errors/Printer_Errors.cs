using System;
using System.Text.RegularExpressions;

//I think this is the first and last time I used regular expressions :(
//https://www.codewars.com/kata/56541980fa08ab47a0000040

public class Printer 
{
    public static string PrinterError(String s) 
    {
        
        return Regex.Replace(s,"[a-m]","").Length +"/"+ s.Length;
    }
}