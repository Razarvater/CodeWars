using System;

//https://www.codewars.com/kata/51ba717bb08c1cd60f00002f

public class RangeExtraction
{
        static int start = 0, end = 0, count = 0;
        static string Result = string.Empty;
        static string PreRes = string.Empty;
        public static string Extract(int[] args)
        {
          start = 0;end = 0;count = 0;Result = String.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (count == 0) { start = args[i]; end = args[i]; }

               
                if (i == args.Length - 1)
                {
                      if (count == 1)
                    {
                        Result += $"{start},{end},";
                        count = 0;
                        start = args[i]; end = args[i];
                    }
                    else if(count < 2)
                    {
                        Result += $"{args[i]},";
                        count = 0;
                        start = args[i]; end = args[i];
                    }
                    else Result += $"{start}-{end},";
                    break;
                }
                    
                if (args[i + 1] == end+1) 
                { 
                    end = args[i + 1];
                    count++; 
                }
                else
                {
                    if (count == 1)
                    { 
                        Result += $"{start},{end},";
                        count = 0;
                        start = args[i]; end = args[i];
                        continue;
                    }
                    if (count < 2)
                    {
                        Result += $"{args[i]},";
                        count = 0;
                        start = args[i]; end = args[i];
                        continue;
                    }

                    Result += $"{start}-{end},";
                    start = args[i]; end = args[i];

                    count = 0;
                }
            }
          
            Result = Result.Remove(Result.Length - 1);
            return Result;
        }
}