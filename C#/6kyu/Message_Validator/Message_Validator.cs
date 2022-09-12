using System;

//https://www.codewars.com/kata/5fc7d2d2682ff3000e1a3fbc

public class Kata
{
   public static bool isAValidMessage(string message)
   {
        int Con = 0;
        bool isCount = false;
        for (int i = 0; i < message.Length; i++)
        {
            if (isCount)
            {
                if (!char.IsDigit(message[i]))
                    Con--;
                if (i + 1 == message.Length && Con != 1)
                {
                    return false;
                }
            }
            if (char.IsDigit(message[i]))
            {
                if ((Con != 0 && i == 0) || (Con != 1 && i != 0) || Prov(i,message))
                {
                    return false;
                }
                Con = Counter(message, ref i);
                isCount = true;
            }
        }
        return true;
    }
    static int Counter(string message, ref int step)
    {
        string Returned = "";
        for (int i = step; i < message.Length - 1; i++, step++)
        {
            if (char.IsDigit(message[i]))
            {
                Returned += message[i];
            }
            else
            {
                break;
            }
        }
        return int.Parse(Returned);
    }
    static bool Prov(int j,string message)
    {
        bool returned = true;
        for (int i = j; i < message.Length-1; i++)
        {
            returned = returned && char.IsDigit(message[i]);
        }
        return returned;
    }
  }