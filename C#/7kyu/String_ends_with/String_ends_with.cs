//https://www.codewars.com/kata/51f2d1cafc9c0f745c00037d

public class Kata
{
  public static bool Solution(string str, string ending)
  {
    if(ending.Length>str.Length)return false;
    
    for(int i = ending.Length-1,j = str.Length-1; i>=0 ;i--,j--)
      if(str[j]!=ending[i])return false;
    
    return true;
  }
}