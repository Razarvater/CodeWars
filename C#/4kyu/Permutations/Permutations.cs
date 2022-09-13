using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

//https://www.codewars.com/kata/5254ca2719453dcc0b00027d

class Permutations
{
    public static List<string> SinglePermutations(string s)
    {
        string[] totalarray = new string[s.Length];
        int i = 0;

        foreach (var item in s)
        {
            totalarray[i] = i.ToString();
            i++;
        }
        var list = new List<string>(totalarray);

        var Result = allcombinations(list, new List<string>());
        List<string> Result2 = new List<string>();
        i = 0;
        int j = 0;

        foreach (var item in Result)
        {
            j = 0;
            foreach (var items in item)
            {
                if (j == 0) Result2.Add("");

                Result2[i] += s[int.Parse(items)];
                j++;
            }
            i++;

        }
        return Result2.Distinct().ToList();
    }

    private static IEnumerable<List<string>> allcombinations(List<string> arg, List<string> awithout)
    {
        if (arg.Count == 1)
        {
            var result = new List<List<string>>();
            result.Add(new List<string>());
            result[0].Add(arg[0]);
            return result;
        }
        else
        {
            var result = new List<List<string>>();

            foreach (var first in arg)
            {
                var others0 = new List<string>(arg.Except(new string[1] { first }));
                awithout.Add(first);
                var others = new List<string>(others0.Except(awithout));

                var combinations = allcombinations(others, awithout);
                awithout.Remove(first);

                foreach (var tail in combinations)
                {
                    tail.Insert(0, first);
                    result.Add(tail);
                }
            }
            return result;
        }
    }
}