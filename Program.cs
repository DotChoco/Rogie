using RDE.Core;
using RDE.Media.Audio;
using System;

namespace Rogie;
class Program {
  static void Main() {

    Application.SetDebugMode(DebugMode.INTERNAL);
    Console.Clear();
    // Application.ExportAssets();
    Console.WriteLine(Application.Path);

    // Game game = new();
    AudioSource src = new();
    // src.SourcePath = $@"{Application.AssetsPath}\Music\revnuyu.ogg";
    // src.SourcePath = $@"{Application.AssetsPath}\Music\revnuyu.ogg";
    src.SourcePath = $@"{Application.AssetsPath}\Music\DJ Satomi - Waves.mp3";
    Console.WriteLine(src.SourcePath);

    src.Format = AudioFormat.MP3;
    // src.Format = AudioFormat.OGG;
    // src.Format = AudioFormat.WAV;
    // src.Format = AudioFormat.FLAC;

    AudioPlayer aup = new(src);
    aup.Play();

  }
}
