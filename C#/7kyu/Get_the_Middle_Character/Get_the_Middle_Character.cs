//https://www.codewars.com/kata/56747fd5cb988479af000028

public class Kata
{
  public static string GetMiddle(string s)
  {
    string result = "";
        bool isCh;
        isCh = s.Length % 2 == 0;
        if (isCh)
        {
            result = result + s[s.Length / 2 - 1] + s[s.Length / 2];
        }
        else
        {
            result = result + s[s.Length / 2];
        };
    return result;
  }
}