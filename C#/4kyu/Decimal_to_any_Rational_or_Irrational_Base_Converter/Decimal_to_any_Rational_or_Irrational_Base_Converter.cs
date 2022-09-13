using System;

//https://www.codewars.com/kata/5509609d1dbf20a324000714

public class Converter
{

  public static string Convert(double n, int decimals, double nbase) 
  {
    string collection = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string result = (n < 0) ? "-" : "";
    n = Math.Abs(n);
    var l = (n == 0.0) ? 0 : (int)Math.Log(n, nbase);
    for (var i = l; i >= -decimals; i--) {
      var f = Math.Pow(nbase, i);
      var d = (int)(n / f);
      result += collection[d];
      n -= d * f;
      if (i == 0 && decimals > 0) result += ".";
    }
    return result;
  }
}