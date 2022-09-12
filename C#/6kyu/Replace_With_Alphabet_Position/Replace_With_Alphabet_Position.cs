//https://www.codewars.com/kata/546f922b54af40e1e90001da

public static class Kata
{
  public static string AlphabetPosition(string text)
  {
        int temp;
        if(text == string.Empty)
          return string.Empty;
        string Result = "";
        string a = "abcdefghijklmnopqrstuvwxyz";
        string b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int iter = 0;
        foreach (var item in text)
        {
            temp = a.IndexOf(item)+1;
            if(temp == 0)
                temp = b.IndexOf(item) + 1;
            if (iter == 0  && temp!=0)
            {
                iter++;
                Result += temp;
                continue;
            }
            if(temp!=0)
                Result += " " + temp;
        }
    return Result;
  }
}