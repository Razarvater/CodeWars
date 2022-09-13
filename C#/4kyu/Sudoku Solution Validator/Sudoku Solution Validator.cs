//https://www.codewars.com/kata/529bf0e9bdf7657179000008

public class Sudoku
{
  public static bool ValidateSolution(int[][] board)
  {
    int sum = 45;
    int temp = sum;
    for(int i = 0;i<board.Length;i++)
      {
      temp = sum;
      
        for(int j = 0; j<board.Length;j++)
          temp-=board[i][j];
      
        if(temp!=0) return false;
      }
    
    for(int i = 0;i<board.Length;i+=3)
      {
          for(int j = 0; j<board.Length;j+=3)
            {
            temp = sum;
              for(int x = i; x<i+3;x++)
                for(int y = j;y<j+3;y++)
                    temp-=board[x][y];
                  
            if(temp !=0) return false;
            }
      }
    
    return true;
  }
}