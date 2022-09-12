using System;
using System.Net;

//https://www.codewars.com/kata/52e88b39ffb6ac53a400022e

public class Kata
{
  public static string UInt32ToIP(uint ip)
  {
    int intAddress = BitConverter.ToInt32(IPAddress.Parse(ip.ToString()).GetAddressBytes(), 0);
    return new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
  }
}