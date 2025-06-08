using RDE.Core.Behavior;
using RDE.Media.Audio;
// using System.Threading.Tasks;
using System;

namespace Rogie;
class Program {
  static void Main() {

    Console.Clear();
    Application.SetBuildMode(BuildMode.NONE);

    // Game game = new();
    AudioSource src = new();

    // src.SourcePath = $@"{Application.AssetsPath}\Music\DJ Satomi - Waves.mp3";
    src.SourcePath = $@"{Application.AssetsPath}\Music\If_I_could.ogg";
    // src.SourcePath = $@"{Application.AssetsPath}\Music\Got-me-dancing.ogg";
    // src.SourcePath = $@"{Application.AssetsPath}\Music\Love_Song.flac";
    // src.SourcePath = $@"{Application.AssetsPath}\Music\Bounce.wav";
    Console.WriteLine(src.SourcePath);

    AudioPlayer aup = new(src);
    Console.WriteLine("Presiona:");
    Console.WriteLine("  P = Play/Reanudar");
    Console.WriteLine("  S = Pausa");
    Console.WriteLine("  Q = Salir");

    while (true)
    {
      var key = Console.ReadKey(true).Key;

      switch (key)
      {
        case ConsoleKey.P:
          aup.Play();
          break;
        case ConsoleKey.S:
          aup.Pause();
          break;
        case ConsoleKey.Q:
          aup.Stop();
          return;
      }
    }

    // await Task.Run(() =>
    // {
    //   while (true)
    //   {
    //     var key = Console.ReadKey(true).Key;
    //
    //     switch (key)
    //     {
    //         case ConsoleKey.P:
    //           aup.Play();
    //           Console.WriteLine("Play");
    //           break;
    //         case ConsoleKey.S:
    //           aup.Pause();
    //           Console.WriteLine("Pause");
    //           break;
    //         case ConsoleKey.Q:
    //           aup.Stop();
    //           Console.WriteLine("Stop");
    //           return;
    //     }
    //   }
    // });
    // Console.WriteLine(.content);

  }
}
