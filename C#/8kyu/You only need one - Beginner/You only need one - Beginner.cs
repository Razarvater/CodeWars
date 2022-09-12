//https://www.codewars.com/kata/57cc975ed542d3148f00015b

public class Kata
{
  public static bool Check(object[] a, object x)
  {
    foreach(var item in a)
        if(object.Equals(item,x)) return true;

    return false;
  }
}