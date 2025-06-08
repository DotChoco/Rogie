using NAudio.Wave;
using System;
using System.Threading;
using RDE.Core.Logs;

namespace RDE.Media.Audio;

public sealed class Flac: GuideLines{

private Log _log = new(){content = "Success"};

public Flac(){}

public Log Play(string SourcePath){
  _sourcePath = SourcePath;

  if(_sourcePath == null || _sourcePath == string.Empty){
    Log.content = "Empty Path";
    return _log;
  }

  using var reader = new NAudio.Flac.FlacReader(_sourcePath);
  using var player = new DirectSoundOut();

  player.Init(reader);
  player.Play();

  Thread.Sleep(reader.TotalTime);
  // Console.WriteLine(reader.TotalTime);

  return _log;
}



}
