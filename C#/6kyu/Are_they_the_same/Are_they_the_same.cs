//https://www.codewars.com/kata/550498447451fbbd7600041c

class AreTheySame
{
  public static bool comp(int[] a, int[] b)
  {
   if (a == null || b == null || a.Length != b.Length)
            return false;
        bool Result = true;

        for (int i = 0; i < b.Length; i++)
        {
            if (b[i] < 0) return false;

            for (int j = 0; j < a.Length; j++)
            {
                if (b[i] == a[j] * a[j])
                {
                    a[j] = 0;
                    break;
                }
                else if (j == a.Length - 1)
                    return false;

                if (a[j] == 0)
                    continue;
            }
        }
    return Result;
  }
}