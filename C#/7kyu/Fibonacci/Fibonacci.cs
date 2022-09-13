//https://www.codewars.com/kata/57a1d5ef7cb1f3db590002af

public class Fibonacci
{
    public static int Fib(int n)
    {      
        int second = 0;
        int k = 1;
        int first = 0;
        for(int i = 0; i<n-1;i++)
          {
            first = second;
            second = k;
            k = first+second;            
          }
        return k;
    }
}