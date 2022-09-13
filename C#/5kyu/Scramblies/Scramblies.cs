using System;

//https://www.codewars.com/kata/55c04b4cc56a697bb0000048

public class Scramblies 
{
    public static bool Scramble(string str1, string str2)
    {
      if (str2.Length > str1.Length) return false;

        bool Result = true;
        char[] help = str1.ToCharArray();
        char[] help2 = str2.ToCharArray();
        for (int i = 0; i < help2.Length; i++)
        {
            if (Array.IndexOf(help, help2[i]) != -1)
                help[Array.IndexOf(help, help2[i])] = '/';
            else
                return false;
        }
        return Result;
    }

}