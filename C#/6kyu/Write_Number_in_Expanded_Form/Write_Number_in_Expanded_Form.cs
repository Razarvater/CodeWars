using System;

//https://www.codewars.com/kata/5842df8ccbd22792a4000245

public static class Kata 
{
    public static string ExpandedForm(long num) 
    {
        string Result = "";
      string temp = "";
      string nums = num.ToString();
        int countNull = nums.Length;
      
      
      
      
        foreach(var item in nums)
          {
            countNull--;
            temp = "";
             for(int i = 0; i < countNull;i++)
               temp += '0';
          
            
            if(item != '0' && countNull !=0 )
              Result += item + temp + " + ";   
            else  if(item != '0' )
              Result += item + temp;
          }
      if(nums.Length < 2) return  Result;
      
      
      System.Console.WriteLine(Result[Result.Length-2]);
      if(Result[Result.Length-2] == '+')
        {
          for(int i =0;i<3;i++)
            Result = Result.Remove(Result.Length-1);
        }
      
       return Result;
    }
}