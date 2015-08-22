using Steamworks;
using System;

namespace SteamReplacer
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      if (args.Length < 2)
      {
        Console.WriteLine("Run app with steam appid and game path. \r\n Example: 'SteamReplacer.exe 1200 C:\\Games\\SomeGame\\game.exe'");
        return;
      }

      var game = new Game(args);
      Environment.SetEnvironmentVariable("SteamAppId", game.AppId.ToString());
      if (SteamAPI.Init())
      {
        Console.WriteLine("User Name = '{0}', SteamID = '{1}'", SteamFriends.GetPersonaName(), SteamUser.GetSteamID());
        if (!game.Run())
          Console.WriteLine("Game already started or game file not found.");
      }
      else
        Console.WriteLine("Steam not found. Run Steam and try again.");
    }

  }

}
