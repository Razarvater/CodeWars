//https://www.codewars.com/kata/54da539698b8a2ad76000228

public class Kata
{
  public static bool IsValidWalk(string[] walk)
  {
    int X_temp = 0;
    int Y_temp = 0;
    int Counter = 0;
    foreach(var item in walk)
      {
        Counter++;
        if(Counter>10)return false;
      
        switch(item[0])
          {
            case 'n': Y_temp++;
              break;
             case 's':Y_temp--;
              break;
             case 'w':X_temp++;
              break;
             case 'e':X_temp--;
              break;
          }
      }
    
    if(X_temp == 0 && Y_temp == 0 && Counter==10)return true;
    
    return false;
  }
}