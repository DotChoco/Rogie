using RDE.Core.Logs;
using System;

namespace RDE.Media.Audio;

public interface GuideLines{
  TimeSpan CurrentTime { get; }
  Log Log { get; }

  void LoadAudio(string SourcePath);
  void Play(string SourcePath);
  void Stop();
  void Pause();
  void Backward(int sec);
  void Forward(int sec);
  void Reset();
}
