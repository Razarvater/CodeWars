using System;

//https://www.codewars.com/kata/534e01fbbb17187c7e0000c6

public class Spiralizor
{
   public enum Rotations
        {
            LEFT, RIGHT, UP, Down
        }
    public static int[,] Spiralize(int size)
    {
        int N = size;
                Rotations rotations = Rotations.RIGHT;
                int CountSkip = 2;
                int[,] ResultArray = new int[N, N];
                ResultArray[0, 0] = 1;
                for (int i = 0; i < N;)
                    for (int j = 0; j < N;)
                    {
                        if (N % 2 == 0 && ((i == N / 2 && j == N / 2) || (i == N / 2 && j == N / 2 - 1) || (i == N / 2 - 1 && j == N / 2)))
                        {
                            CountSkip--;
                            if (CountSkip <= 0)
                            {
                                i = N;
                                j = N;
                                continue;
                            }
                        }
                        if (N % 4 != 0)
                        {
                            try
                            {
                                switch (rotations)
                                {
                                    case Rotations.LEFT:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i - 2, j] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.RIGHT:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i - 2, j] == 1 && ResultArray[i, j + 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.UP:
                                        if (ResultArray[i - 2, j] == 1 && ResultArray[i, j + 2] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.Down:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i, j + 2] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                }

                                switch (rotations)
                                {
                                    case Rotations.LEFT:
                                        if (ResultArray[i, j - 1] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.RIGHT:
                                        if (ResultArray[i, j + 1] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.UP:
                                        if (ResultArray[i - 1, j] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.Down:
                                        if (ResultArray[i + 1, j] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                        }
                        
                        switch (rotations)
                        {
                            case Rotations.LEFT:
                                j--;
                                try
                                {
                                    if (ResultArray[i, j - 2] == 1)
                                        rotations = Rotations.UP;
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        if (ResultArray[i, j - 1] == 1) ;
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        rotations = Rotations.UP;
                                    }
                                }
                                break;

                            case Rotations.RIGHT:
                                j++;
                                try
                                {
                                    if (ResultArray[i, j + 2] == 1)
                                        rotations = Rotations.Down;
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        if (ResultArray[i, j + 1] == 1) ;
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        rotations = Rotations.Down;
                                    }
                                }
                                break;

                            case Rotations.UP:
                                i--;
                                try
                                {
                                    if (ResultArray[i - 2, j] == 1)
                                        rotations = Rotations.RIGHT;
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        if (ResultArray[i - 1, j] == 1) ;
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        rotations = Rotations.RIGHT;
                                    }
                                }
                                break;
                            case Rotations.Down:
                                i++;
                                try
                                {
                                    if (ResultArray[i + 2, j] == 1)
                                        rotations = Rotations.LEFT;
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        if (ResultArray[i + 1, j] == 1) ;
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        rotations = Rotations.LEFT;
                                    }
                                }
                                break;
                        }
                        if (N % 4 == 0)
                        {
                            try
                            {
                                switch (rotations)
                                {
                                    case Rotations.LEFT:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i - 2, j] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.RIGHT:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i - 2, j] == 1 && ResultArray[i, j + 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.UP:
                                        if (ResultArray[i - 2, j] == 1 && ResultArray[i, j + 2] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.Down:
                                        if (ResultArray[i + 2, j] == 1 && ResultArray[i, j + 2] == 1 && ResultArray[i, j - 2] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                }

                                switch (rotations)
                                {
                                    case Rotations.LEFT:
                                        if (ResultArray[i, j - 1] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.RIGHT:
                                        if (ResultArray[i, j + 1] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.UP:
                                        if (ResultArray[i - 1, j] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                    case Rotations.Down:
                                        if (ResultArray[i + 1, j] == 1)
                                        {
                                            i = N;
                                            j = N;
                                            continue;
                                        }
                                        break;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                        }
                            ResultArray[i, j] = 1;
                    }
                
      return ResultArray;      
    }
}