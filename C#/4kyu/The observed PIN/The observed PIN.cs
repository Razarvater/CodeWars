using System.Collections.Generic;

//https://www.codewars.com/kata/5263c6999e0f40dee200059d

public class Kata
{
  private static int Length;
    public static List<string> GetPINs(string observed)
    {
        Length = observed.Length;
        List<string> Result = new List<string>();
        List<List<string>> ObservedVariants = new List<List<string>>();
        GetVarDigits(ObservedVariants,observed);
        GetAllCombinations(ObservedVariants, Result,string.Empty,0);
        return Result;
    }
    public static void GetAllCombinations(List<List<string>> tmp, List<string> result,string temp, int RecDepth)
      {
        if (temp != string.Empty && RecDepth == Length)
            {
                result.Add(temp);
                return;
            }
            string temp2 = temp;
            foreach (var item in tmp[RecDepth])
            {
                temp += item;
                GetAllCombinations(tmp, result, temp, RecDepth + 1);
                temp = temp2;
            }
      }
    
    public static void GetVarDigits(List<List<string>> tmp, string obs)
    {
      foreach(var item in obs)
        {
          switch(item)
            {
              case '0':
                tmp.Add(new List<string>(){"0","8"});
                break;
              case '1':
                tmp.Add(new List<string>(){"1","2","4"});
                break;
              case '2':
                tmp.Add(new List<string>(){"1","2","3","5"});
                break;
              case '3':
                tmp.Add(new List<string>(){"2","3","6"});
                break;
              case '4':
                tmp.Add(new List<string>(){"1","4","5","7"});
                break;
              case '5':
                tmp.Add(new List<string>(){"2","4","5","6","8"});
                break;
              case '6':
                tmp.Add(new List<string>(){"3","5","6","9"});
                break;
              case '7':
                tmp.Add(new List<string>(){"4","7","8"});
                break;
              case '8':
                tmp.Add(new List<string>(){"0","5","7","8","9"});
                break;
              case '9':
                tmp.Add(new List<string>(){"6","8","9"});
                break;
            }
        }
    }
}