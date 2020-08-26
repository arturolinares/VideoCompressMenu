# Video Compress Menu

This is a quick tool to add a context menu to compress videos from Windows Explorer.

Motivated by having to [share quick screencasts](https://arturo.linar.es/transcode-a-video-using-a-context-menu-on-windows) that are smaller than the Xbox recorder generates.

The resized video will be saved with the same name, but with the `-small.mp4` suffix.

# Install

```
VideoCompressMenu.exe --install
```

# Uninstall

```
VideoCompressMenu.exe --uninstall
```

# Dependencies

The tool uses VLC to do the actual work. It looks for the `vlc.exe` binary in `C:\Program Files\VideoLAN\VLC\vlc.exe`. If you installed on another location, you can use the environment variable `VLC_EXEC_PATH` to point to it.
