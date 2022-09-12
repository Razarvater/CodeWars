//https://www.codewars.com/kata/58dced7b702b805b200000be

public class Kata
{
  public static double DistanceBetweenPoints(Point a, Point b)
  {
        return System.Math.Sqrt(System.Math.Pow(b.X - a.X,2) + System.Math.Pow(b.Y - a.Y,2));
  }
}