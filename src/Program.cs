using System;
using SharpTools;

namespace VideoCompressMenu
{
  class Program
  {
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            showUsage();
            return;
        }

        foreach (var arg in args)
        {
            if (!arg.StartsWith("--")) {
                continue;
            }

            switch (arg)
            {
                case "--install":
                    var vlcProcess = new VlcCommandBuilder("%1");
                    var exe = vlcProcess.GetVlcExec();
                    var vlcArgs = vlcProcess.BuildCommandArgs();

                    ShellFileType.AddAction("mp4", "optimize_video_720p",
                        "Optimize video to 720p", $"{exe} {vlcArgs}");

                    break;
                case "--uninstall":
                    ShellFileType.RemoveAction("mp4", "optimize_video_720p");
                    break;
                default:
                    showUsage();
                    return;
            }
        }
    }

    private static void showUsage()
    {
        var cmd = System.AppDomain.CurrentDomain.FriendlyName;

        Console.WriteLine($"Usage: {cmd} [options]");
        Console.WriteLine("  Options:");
        Console.WriteLine("     --install\t\t\tInstalls the context menu.");
        Console.WriteLine("     --uninstall\t\tRemoves the contextual menu.");
    }
  }
}
