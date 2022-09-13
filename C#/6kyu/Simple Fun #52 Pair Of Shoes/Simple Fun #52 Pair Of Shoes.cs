//https://www.codewars.com/kata/58885a7bf06a3d466e0000e3

namespace myjinxin
{
    using System;
    
    public class Kata
    {
        public bool PairOfShoes(int[][] shoes)
        {
          int counter = 0;
          int lng = shoes.Length;
          for(int i = 0;i<lng;i++)
            {
            if(shoes[i][0]==10)continue;
            
                for(int j = 0;j<lng;j++)
                  {
                      if(shoes[i][0] == shoes[j][0]-1 || shoes[i][0]-1 == shoes[j][0])
                        if(shoes[i][1]==shoes[j][1])
                          {
                            shoes[i][0]=10;
                            shoes[j][0]=10;
                            counter+=2;
                            break;
                          }
                  }
            }
          return counter==lng;
        }
    }
}