using System;
using Steamworks;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace SteamReplacer
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      var game = new Game(args);
      Environment.SetEnvironmentVariable("SteamAppId", game.AppId.ToString());

      if (SteamAPI.Init())
        game.Run();
    }

  }

  internal class Game
  {
    internal long AppId { get; set; }

    internal FileInfo FilePath { get; set; }

    internal bool Exists { get { return this.FilePath.Exists; } }

    internal DirectoryInfo WorkingDirectory { get { return this.FilePath.Directory; } }

    internal void Run()
    {
      var processInfo = new ProcessStartInfo() { FileName = this.FilePath.FullName, WorkingDirectory = WorkingDirectory.FullName };
      Process.Start(processInfo);
    }

    internal Game(string[] args)
    {
      this.AppId = long.Parse(args[0]);
      this.FilePath = new FileInfo(args[1]);
    }
  }
}
