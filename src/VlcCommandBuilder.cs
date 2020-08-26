using System;
using System.Diagnostics;
using System.IO;

namespace VideoCompressMenu
{
  internal class VlcCommandBuilder
  {
    private string file;

    public VlcCommandBuilder(string file)
    {
      this.file = file;
    }

    internal void Run()
    {
        var vlcCommand = BuildCommandArgs();
        var vlcExec = GetVlcExec();
        executeCommand(vlcExec, vlcCommand);
    }

     static void executeCommand(string vlcExec, string vlcCommand)
    {
        Process p = Process.Start(vlcCommand);
        p.WaitForExit();
    }

    public string BuildCommandArgs()
    {
        var maxWidth = Environment.GetEnvironmentVariable("VLC_MAX_WIDTH") ?? "720";
        var culture = System.Globalization.CultureInfo.CurrentUICulture.ToString();
        var scale = "Automatic";

        if (culture.StartsWith("es"))
        {
            scale = "Automático";
        }

        var command = $"\"-I dummy\" \"{file}\" \":sout=#transcode{{vcodec=h264,scale={scale},width={maxWidth},acodec=mpga,ab=128,channels=2,samplerate=44100,scodec=none}}:std{{access=file{{no-overwrite}},mux=mp4,dst='{file}-small.mp4'}}\" \"vlc://quit\"";

        return command;
    }

    public string GetVlcExec()
    {
      var defaultVlcExec = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
      var exe = Environment.GetEnvironmentVariable("VLC_EXEC_PATH") ?? defaultVlcExec;
      if (!File.Exists(exe))
      {
          var message = $"Couldn't find VLC. I looked in '{defaultVlcExec}'"
            + "but you can change the path setting the VLC_EXEC_PATH environment "
            + "variable.";

          throw new Exception(message);
      }

      return exe;
    }
  }
}