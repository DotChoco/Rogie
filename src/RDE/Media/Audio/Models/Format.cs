using RDE.Core.Logs;
using System;
using NAudio.Wave;

namespace RDE.Media.Audio;

public abstract class Format{

protected TimeSpan _currentTime { get; }
protected string _sourcePath = string.Empty;
protected Log _log { get; } = new();
protected IWavePlayer outputDevice;
protected WaveStream _audioFile;

public bool IsPlaying => outputDevice?.PlaybackState == PlaybackState.Playing;
public bool IsPaused => outputDevice?.PlaybackState == PlaybackState.Paused;



}
