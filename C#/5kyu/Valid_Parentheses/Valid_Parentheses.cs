using System;

//https://www.codewars.com/kata/52774a314c2333f0a7000688

public class Parentheses
{
    public static bool ValidParentheses(string input)
    {
      
        string coll = "";
     
        foreach (var item in input)
        {
            if (item is ')' or '(')
            {
                coll += item;
            };
        };
        int strl = coll.Length;
        int stllast = strl+1;
        for (int i = 0;strl<stllast; i++)
        {
            coll = coll.Replace("()", string.Empty);
          stllast = strl;
          strl = coll.Length;
        }
        return coll.Length==0;
    }
}