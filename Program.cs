using RDE;
using RDE.Behavior;
using RDE.Structs.Enums;
using System;

namespace Rogie;
class Program {
  static void Main(string[] args) {

    Console.Clear();
    // Application.ExportAssets();
    Console.WriteLine(Application.GamePath);

    // Game game = new();
    Audio audio = new();
    audio.Format = AudioFormat.OGG;
    audio.SourcePath = $@"{Application.AssetsPath}\Music\revnuyu.ogg";
    Console.WriteLine(audio.SourcePath);
    // audio.SourcePath = $@"E:/carlo/Download/Pin/Music/Dj_Satomi-sound_of_my_dream.ogg";
    // audio.SourcePath = $@"{Application.AssetsPath}/Music/ssstik.io_1734932779800.flac";
    // audio.SourcePath = $@"{Application.AssetsPath}/Music/ssstik.io_1736893033133.mp3";
    // audio.SourcePath = $@"{Application.AssetsPath}/Music/BGM.wav";
    // audio.Format = AudioFormat.FLAC;

    audio.Play();

  }
}
