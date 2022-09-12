//https://www.codewars.com/kata/5dd462a573ee6d0014ce715b

public class Kata 
{
  public static int SameCase(char a, char b) 
  {
    string collectionA="abcdefghijklmnopqrstuvwxyz";
    string collectionB="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    if(!char.IsLetter(a) || !char.IsLetter(b)) return -1;
    
    if((collectionA.IndexOf(a) !=-1 && collectionA.IndexOf(b)!=-1) || (collectionB.IndexOf(a) !=-1 && collectionB.IndexOf(b)!=-1))
      return 1;
    
    return 0;
  }
}