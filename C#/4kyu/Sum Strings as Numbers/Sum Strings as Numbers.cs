using System;
using System.Collections.Generic;
using System.Linq;

//https://www.codewars.com/kata/5324945e2ece5e1f32000370

public static class Kata
{
  //But I add up numbers of any size (
    public static string sumStrings(string a, string b)
    {
        string tempS = a;
        foreach (var item in a)
        {
            if (item != '0') break;
            tempS = tempS.Remove(0,1);
        }
        a = tempS;
        tempS = b;
        foreach (var item in b)
        {
            if (item != '0') break;
            tempS = tempS.Remove(0, 1);
        }
        b = tempS;

        if (b == "" && a == "") return "0";

        if (b == "") return a;
        if (a == "") return b;
        System.Console.WriteLine(a + "|" + b);
        //50095301248058391139327916261
        //9223372036854775808
        List<string> First = new List<string>();
        List<string> Second = new List<string>();
        string Result = "";

        
        foreach (var item in a)
            First.Add(item.ToString());
        foreach (var item in b)
            Second.Add(item.ToString());

        int countL;
        int countM;
        if (First.Count > Second.Count)
        {
            countL = First.Count;
            countM = Second.Count;
        }
        else
        {
            countL = Second.Count;
            countM = First.Count;
        }
        int temp = 0;
        int temp2 = 0;
        for (int i = 0; i < countL; i++)
        {
            if (i >= countM)
            {
                if (First.Count > Second.Count)
                    temp2 = int.Parse(First[First.Count - i - 1]) + temp;
                else
                    temp2 = int.Parse(Second[Second.Count - i - 1]) + temp;
            }
            else
                temp2 = int.Parse(First[First.Count-i-1]) + int.Parse(Second[Second.Count - i-1]) + temp;

            temp = 0;

            if (temp2 > 9)
            {
                temp = 1;
                temp2 -= 10;
            }
            Console.WriteLine(temp + "|" + temp2);
            Result += temp2;

            if (i+1 >= countL) Result += temp;
        }
        if (Result[Result.Length-1] == '0') Result = Result.Remove(Result.Length - 1); ; 
        return new string(Result.Reverse().ToArray());
      }
}