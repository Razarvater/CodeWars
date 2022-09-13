using System;
using System.Linq;

//https://www.codewars.com/kata/51c8e37cee245da6b40000bd

public class StripCommentsSolution
{
  public static string StripComments(string text, string[] commentSymbols)
        {
            if (text.Length == 0 || commentSymbols.Length == 0) return string.Empty;

            string Result = string.Empty;
            bool startDeleting = false;

            foreach (var item in text)
            {
                if (Array.IndexOf(commentSymbols, item.ToString()) != -1)
                    startDeleting = true;

                if (item == '\n')
                {
                    startDeleting = false;

                    try
                    {
                        while (true)
                            if (Result[Result.Length - 1] == ' ')
                                Result = Result.Remove(Result.Length - 1);
                            else break;
                    }
                    catch (IndexOutOfRangeException) { }
                }

                if (!startDeleting)
                    Result += item;
            }

            try
            {
                while (true)
                    if (Result[Result.Length - 1] == ' ')
                        Result = Result.Remove(Result.Length - 1);
                    else break;
            }
            catch (IndexOutOfRangeException){}
           
            return Result;
        }
}