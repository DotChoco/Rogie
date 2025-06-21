using NAudio.Wave;
using NAudio.Flac;
using System;
using RDE.Core.Logs;

namespace RDE.Media.Audio;
public sealed class Flac:Format, GuideLines{

public TimeSpan CurrentTime => _currentTime;
public Log Log => _log;


public void LoadAudio(string SourcePath){
  _sourcePath = SourcePath;
  if(outputDevice == null){
    _audioFile = new FlacReader(_sourcePath);
    outputDevice = new DirectSoundOut();
    outputDevice.Init(_audioFile);
  }
}


public void Play(string SourcePath){
  LoadAudio(SourcePath);
  outputDevice.Play();
}

public void Pause() {
  if (IsPlaying)
    outputDevice.Pause();
}

public void Stop() {
  outputDevice?.Stop();
  _audioFile?.Dispose();
  outputDevice?.Dispose();
  _audioFile = null;
  outputDevice = null;
}


public void Backward(int seconds){
  if (IsPlaying && outputDevice != null){
    outputDevice.Pause();
    _audioFile.Skip(seconds * -1);
    outputDevice.Play();
  }
}
public void Forward(int seconds)
{
  if (_audioFile.CurrentTime >= _audioFile.TotalTime.Subtract(TimeSpan.FromSeconds(10)))
    Reset();
  if (IsPlaying && outputDevice != null)
  {
    outputDevice.Pause();
    _audioFile.Skip(seconds);
    outputDevice.Play();
  }
}

public void Reset(){
  outputDevice.Pause();
  _audioFile.CurrentTime = TimeSpan.FromSeconds(0);
  outputDevice.Dispose();
  outputDevice.Init(_audioFile);
}



}
