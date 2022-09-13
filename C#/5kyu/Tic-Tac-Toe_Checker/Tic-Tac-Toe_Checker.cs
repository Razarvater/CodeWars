using System;

//I won't do it again... why did I do it?
//https://www.codewars.com/kata/525caa5c1bf619d28c000335

public class TicTacToe
{
  public int IsSolved(int[,] _Field)
  {
    bool WinF = (_Field[0, 0] == _Field[1, 0] && _Field[1, 0] == 1) && (_Field[0, 0] == _Field[2, 0] && _Field[2, 0] == 1) ||
                (_Field[0, 1] == _Field[1, 1] && _Field[1, 1] == 1) && (_Field[0, 1] == _Field[2, 1] && _Field[2, 1] == 1) || // Три горизонтальные полосы
                (_Field[0, 2] == _Field[1, 2] && _Field[1, 2] == 1) && (_Field[0, 2] == _Field[2, 2] && _Field[2, 2] == 1) ||

                (_Field[0, 0] == _Field[0, 1] && _Field[0, 1] == 1) && (_Field[0, 0] == _Field[0, 2] && _Field[0, 2] == 1) ||
                (_Field[1, 0] == _Field[1, 1] && _Field[1, 1] == 1) && (_Field[1, 0] == _Field[1, 2] && _Field[1, 2] == 1) || //Три вертикальные полосы
                (_Field[2, 0] == _Field[2, 1] && _Field[2, 1] == 1) && (_Field[2, 0] == _Field[2, 2] && _Field[2, 2] == 1) ||

                (_Field[0, 0] == _Field[1, 1] && _Field[1, 1] == 1) && (_Field[0, 0] == _Field[2, 2] && _Field[2, 2] == 1) || // Диагонали
                (_Field[2, 0] == _Field[1, 1] && _Field[1, 1] == 1) && (_Field[2, 0] == _Field[0, 2] && _Field[0, 2] == 1);
    
    bool WinS = (_Field[0, 0] == _Field[1, 0] && _Field[1, 0] == 2) && (_Field[0, 0] == _Field[2, 0] && _Field[2, 0] == 2) ||
                (_Field[0, 1] == _Field[1, 1] && _Field[1, 1] == 2) && (_Field[0, 1] == _Field[2, 1] && _Field[2, 1] == 2) || // Три горизонтальные полосы
                (_Field[0, 2] == _Field[1, 2] && _Field[1, 2] == 2) && (_Field[0, 2] == _Field[2, 2] && _Field[2, 2] == 2) ||

                (_Field[0, 0] == _Field[0, 1] && _Field[0, 1] == 2) && (_Field[0, 0] == _Field[0, 2] && _Field[0, 2] == 2) ||
                (_Field[1, 0] == _Field[1, 1] && _Field[1, 1] == 2) && (_Field[1, 0] == _Field[1, 2] && _Field[1, 2] == 2) || //Три вертикальные полосы
                (_Field[2, 0] == _Field[2, 1] && _Field[2, 1] == 2) && (_Field[2, 0] == _Field[2, 2] && _Field[2, 2] == 2) ||

                (_Field[0, 0] == _Field[1, 1] && _Field[1, 1] == 2) && (_Field[0, 0] == _Field[2, 2] && _Field[2, 2] == 2) || // Диагонали
                (_Field[2, 0] == _Field[1, 1] && _Field[1, 1] == 2) && (_Field[2, 0] == _Field[0, 2] && _Field[0, 2] == 2);
       
      
    if(WinF)return 1;
    if(WinS)return 2;
    
    
    for(int i = 0; i<3;i++)
      {
        for(int j = 0; j<3;j++)
          {
            if(_Field[i,j] == 0)
              return -1;
          }
      }
    
    return 0;
  }
}