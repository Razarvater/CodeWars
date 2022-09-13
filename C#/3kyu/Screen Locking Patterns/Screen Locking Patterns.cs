using System;
using System.Linq;

//https://www.codewars.com/kata/585894545a8a07255e0002f1

public class Kata
{
        public static int depthRecursion = 2;
        public static int PatternCounter = 0;
        public static int CountPatternsFrom(char firstDot, int length)
        {
            Console.WriteLine(firstDot + "|" + length);
            depthRecursion = length;
            PatternCounter = 0;
            PatternKey start = new PatternKey(firstDot.ToString());

            RecursionKey(start);

            return PatternCounter;
        }

        static void RecursionKey(PatternKey key)
        {
            if (key.length == depthRecursion)
            {
                PatternCounter++;
                return;
            }

            switch (key.name[key.name.Length - 1])
            {
                case 'A':
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));

                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') != -1 && Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') != -1 && Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    break;

                case 'B':
                    if (Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));

                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    break;

                case 'C':
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));

                    if (Array.IndexOf(key.name.ToArray(), 'F') != -1 && Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') != -1 && Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    break;

                case 'D':
                    if (Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    if (Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));

                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    break;

                case 'E':
                    if (Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    if (Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    break;

                case 'F':
                    if (Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    if (Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));

                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    break;

                case 'G':
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));

                    if (Array.IndexOf(key.name.ToArray(), 'D') != -1 && Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'H') != -1 && Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    break;

                case 'H':
                    if (Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'I') == -1)
                        RecursionKey(new PatternKey(key.name + 'I'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    if (Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));

                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    break;

                case 'I':
                    if (Array.IndexOf(key.name.ToArray(), 'H') == -1)
                        RecursionKey(new PatternKey(key.name + 'H'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') == -1)
                        RecursionKey(new PatternKey(key.name + 'F'));
                    if (Array.IndexOf(key.name.ToArray(), 'D') == -1)
                        RecursionKey(new PatternKey(key.name + 'D'));
                    if (Array.IndexOf(key.name.ToArray(), 'B') == -1)
                        RecursionKey(new PatternKey(key.name + 'B'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') == -1)
                        RecursionKey(new PatternKey(key.name + 'E'));

                    if (Array.IndexOf(key.name.ToArray(), 'H') != -1 && Array.IndexOf(key.name.ToArray(), 'G') == -1)
                        RecursionKey(new PatternKey(key.name + 'G'));
                    if (Array.IndexOf(key.name.ToArray(), 'F') != -1 && Array.IndexOf(key.name.ToArray(), 'C') == -1)
                        RecursionKey(new PatternKey(key.name + 'C'));
                    if (Array.IndexOf(key.name.ToArray(), 'E') != -1 && Array.IndexOf(key.name.ToArray(), 'A') == -1)
                        RecursionKey(new PatternKey(key.name + 'A'));
                    break;

            }
        }
    }

  public class PatternKey
    {
        public string name = "";
        public int length = 0;

        public PatternKey(string startname)
        {
            name = startname; 
            length = name.Length;   
        }
    
    }