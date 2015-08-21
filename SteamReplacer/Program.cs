using System;
using Steamworks;

namespace SteamReplacer
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      var appId = long.Parse("1200");
      Environment.SetEnvironmentVariable("SteamAppId", appId.ToString());

      if (!SteamAPI.Init())
      {
        return;
      }
    }
  }
}
