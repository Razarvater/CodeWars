using System;
using System.Collections;
using System.Collections.Generic;

//https://www.codewars.com/kata/5629db57620258aa9d000014

public class Mixing 
{
   public static string Mix(string s1, string s2)
    {
        int[] collectionsCount1 = new int[26];
        int[] collectionsCount2 = new int[26];
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        List<string> PreResult = new List<string>();
        string Result = string.Empty;

        foreach (var item in s1)
        {
            if (alphabet.IndexOf(item) != -1)
                collectionsCount1[alphabet.IndexOf(item)]++;
        }
        foreach (var item in s2)
        {
            if (alphabet.IndexOf(item) != -1)
                collectionsCount2[alphabet.IndexOf(item)]++;
        }
        string temp = string.Empty;
        for (int i = 0; i < 26; i++)
        {
            if (collectionsCount1[i] <= 1 && collectionsCount2[i] <= 1) continue;

            if (collectionsCount1[i] > collectionsCount2[i])
            {
                temp += "1:";
                for (int j = 0; j < collectionsCount1[i]; j++)
                    temp += alphabet[i];
                temp += "/";
                  PreResult.Add(temp);
            }
            else if (collectionsCount1[i] < collectionsCount2[i])
            {
                temp += "2:";
                for (int j = 0; j < collectionsCount2[i]; j++)
                    temp += alphabet[i];
                temp += "/";
                  PreResult.Add(temp);
            }
            else
            {
                temp += "=:";
                for (int j = 0; j < collectionsCount1[i]; j++)
                    temp += alphabet[i];
                temp += "/";
                  PreResult.Add(temp);
            }

            temp = string.Empty;
        }
        PreResult.Sort((string x, string y) => x.Length.CompareTo(y.Length));
        PreResult.Reverse();

        List<List<string>> PREPREResult = new List<List<string>>();
        List<string> PREPREtemp = new List<string>();
        int temp2 = 0;
        int iter = 0;

        foreach (var item in PreResult)
        {
            
            if (item.Length != temp2)
            {
                PREPREResult.Add(PREPREtemp.GetRange(0, PREPREtemp.Count));
                 iter = 0;
                PREPREtemp.Clear();
            }
          if (iter == 0)
            {
                temp2 = item.Length;
                iter++;
            }
            PREPREtemp.Add(item);
        }

        PREPREResult.Add(PREPREtemp.GetRange(0, PREPREtemp.Count));
        PREPREtemp.Clear();
        int temp3 = 0;

        List<List<string>> temp4 = new List<List<string>>();
        List<string> First = new List<string>();
        List<string> Second = new List<string>();
        foreach (var item in PREPREResult)//разложим на ещё 2 подлиста
        {
            foreach (var col in item)
            {
                if (int.TryParse(col.AsSpan(0,1), out temp3))
                    First.Add(col);
                else
                    Second.Add(col);
            }
            temp4.Add(First.GetRange(0, First.Count));
            temp4.Add(Second.GetRange(0, Second.Count));
            First.Clear();
            Second.Clear();
        }
        foreach (var item in temp4)
        {
            item.Sort();
        }
        PREPREResult = temp4.GetRange(0, temp4.Count);

        PreResult.Clear();

        foreach (var item in PREPREResult)
        {
            foreach (var col in item)
            {
                PreResult.Add(col);
            }
        }

        foreach (var item in PreResult)
        {
            Result += item;
        }
     if(Result.Length > 0)
        Result = Result.Remove(Result.Length - 1);
     
        return Result;
    }
}