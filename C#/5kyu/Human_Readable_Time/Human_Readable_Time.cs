//https://www.codewars.com/kata/52685f7382004e774f0001f7

public static class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        string Result ="";
      int HourCount = (seconds/3600);
      int MinutesCount;
      int SecondsCount;
      
        if(HourCount < 10)
          Result+="0" + HourCount + ":";
        else    
          Result+=HourCount + ":";
      
       MinutesCount = (seconds - HourCount*3600)/60; 
      if(MinutesCount < 10)
          Result+="0" + MinutesCount + ":";
        else    
          Result+=MinutesCount + ":";
      
      SecondsCount = seconds - HourCount*3600 -  MinutesCount*60;
      if(SecondsCount < 10)
          Result+="0" + SecondsCount;
        else    
          Result+=SecondsCount;
      
        return Result;
    }
}