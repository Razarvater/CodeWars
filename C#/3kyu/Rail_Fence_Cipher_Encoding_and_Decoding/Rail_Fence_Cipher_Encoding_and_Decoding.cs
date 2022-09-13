using System;

//This is my first 3 kata and I suffered a lot :)
//https://www.codewars.com/kata/58c5577d61aefcf3ff000081

public class RailFenceCipher
{
   public static string Encode(string s, int n)
    {
        int h = s.Length;
        char[,] code = new char[n, h];
        string code2 = "";
        bool up_down = false;
        int rail = 0, pos = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < h; j++)
            {
                code[i, j] = '*';
            }
        }
        for (int i = 0; i < h; i++)
        {
            if (rail == n - 1 || rail == 0)
                up_down = !up_down;

            code[rail, pos++] = s[i];

            if (up_down)
                rail++;
            else
                rail--;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (code[i, j] == '*') continue;
                code2 += code[i, j];
            }
        }
        return code2;
    }
    public static string Decode(string s, int n)
    {
        char[][] decode = new char[n][];
        for (int i = 0; i < decode.Length; i++)
        {
            decode[i] = new char[s.Length];
        }
        int RowIncrement = 1;
        int textIdX = 0;

        for (int i = 0; i < decode.Length; i++)
        {
            for (int rails = 0,pos = 0; pos < decode[rails].Length; pos++)
            {
                if (rails + RowIncrement == decode.Length || rails + RowIncrement == -1)
                {
                    RowIncrement *= -1;
                }
                if (rails == i)
                {
                    decode[rails][pos] = s[textIdX++];
                }
                rails += RowIncrement;
            }
        }

        char[][] resultM = new char[decode[0].Length][];
        for (int i = 0; i < resultM.Length; i++)
        {
            resultM[i] = new char[decode.Length];
        }

        for (int i = 0; i < resultM.Length; i++)
        {
            for (int j = 0; j < resultM[i].Length; j++)
            {
                resultM[i][j] = decode[j][i]; 
            }
        }
        string result = "";
        for (int i = 0; i < resultM.Length; i++)
        {
            for (int j = 0; j < resultM[i].Length; j++)
            {
                if (resultM[i][j] != '\0')
                {
                    result+=resultM[i][j];
                }
            }
        }
        return result;
    }
}