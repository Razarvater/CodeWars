using System;
using System.Collections.Generic;

//https://www.codewars.com/kata/58905bfa1decb981da00009e

public class Dinglemouse
{
    public static int[] TheLift(int[][] queues, int capacity)
    {
        Lift lift = new Lift(capacity,queues);
        return lift.ResultP.ToArray();
    }
}
public class Lift
    {
        int y = 0;
        int Direction = 1;
        int[] PeopleS;
        int[][] queue;
        int PeopleInQUEUE = 0;
        int LastEt = -10;
        public List<int> ResultP = new List<int>();

        public Lift(int capacity,int[][]queues)
        {
            PeopleS = new int[capacity];
            queue = queues;
            INIT();
            if(PeopleInQUEUE == 0)
              {
                ResultP.Add(0);
                return;
              }
          
            if(PeopleInQUEUE>0 && queue[0].Length==0) ResultP.Add(0);
            
            while(PeopleInQUEUE != 0) Move();
          
            if (ResultP[ResultP.Count-1]!=0) ResultP.Add(0);
        }
        private void INIT()
        {
            foreach (var item in queue)
                foreach (var helper in item)
                    PeopleInQUEUE++;
          
            for (int i = 0; i < PeopleS.Length; i++)
                PeopleS[i] = -1;
        }
        private bool AddMan(int x)
        {
            for (int i = 0; i < PeopleS.Length; i++)
                if (PeopleS[i] == -1)
                {
                    PeopleS[i] = x;
                    return true;
                }
            return false;
        }
        public void Move()
        {
            
            bool temp = true;
            if (y == LastEt) temp = false;

            for (int i = 0; i < PeopleS.Length; i++)
                if (PeopleS[i] == y)
                {
                    PeopleS[i] = -1;
                    PeopleInQUEUE--;
                    if (temp)
                    {
                        ResultP.Add(y);
                        LastEt = y;
                        temp = false;
                    }
                }
          
            if (y + Direction == queue.Length || y + Direction == -1) Direction = -Direction;
          
            for (int i = 0; i < queue[y].Length; i++)
                if (((queue[y][i] > y && Direction == 1) || (queue[y][i] < y && Direction == -1)) && queue[y][i] != -1)
                {
                    if (AddMan(queue[y][i]))
                    {
                        queue[y][i] = -1;
                        if (temp)
                        {
                            LastEt = y;
                            ResultP.Add(y);
                            temp = false;
                        }
                    }
                }
          
            if (temp)
                for (int i = 0; i < queue[y].Length; i++)
                    if (queue[y].Length > 0 && queue[y][i] != -1&& ((queue[y][i] > y && Direction == 1) || (queue[y][i] < y && Direction == -1)))
                    {
                        ResultP.Add(y);
                        temp = false;
                        break;
                    }
          
            y += Direction;
        }
    }