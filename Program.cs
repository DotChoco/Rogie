namespace Rogie;
using System;
using RDE;
using RDE.Behavior;
using RDE.Structs.Enums;

class Program {
    static void Main(string[] args) {
        // Application.ExportAssets();
        Console.WriteLine(Application.AssetsPath);
        Console.Clear();

        // Game game = new();
        Audio audio = new();
        audio.Format = AudioFormat.MP3;

        // audio.SourcePath = $@"{Application.AssetsPath}\Music\revnuyu.ogg";
        // audio.SourcePath = $@"{Application.AssetsPath}\Music\ssstik.io_1734932779800.flac";
        audio.SourcePath = $@"{Application.AssetsPath}\Music\ssstik.io_1736893033133.mp3";
        // audio.SourcePath = $@"{Application.AssetsPath}\Music\BGM.wav";
        


        audio.Play();


    }
}
