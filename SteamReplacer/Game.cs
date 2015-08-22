using System.Diagnostics;
using System.IO;

namespace SteamReplacer
{
  internal class Game
  {
    internal long AppId { get; set; }

    internal FileInfo FilePath { get; set; }

    internal bool Exists { get { return this.FilePath.Exists; } }

    internal DirectoryInfo WorkingDirectory { get { return this.FilePath.Directory; } }

    private Process process;

    internal bool Run()
    {
      if (this.Exists && (process == null || process.HasExited))
      {
        var processInfo = new ProcessStartInfo() { FileName = this.FilePath.FullName, WorkingDirectory = WorkingDirectory.FullName };
        this.process = Process.Start(processInfo);
        return true;
      }
      return false;
    }

    internal Game(string[] args)
    {
      if (args.Length > 1)
      {
        this.AppId = long.Parse(args[0]);
        this.FilePath = new FileInfo(args[1]);
      }
    }
  }
}
