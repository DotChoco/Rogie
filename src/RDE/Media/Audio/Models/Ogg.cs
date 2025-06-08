using NVorbis;
// using System.Threading;
using NAudio.Wave;

namespace RDE.Media.Audio;

public sealed class Ogg: GuideLines{

private IWavePlayer outputDevice;
private VorbisWaveReader audioFile;

public bool IsPlaying => outputDevice?.PlaybackState == PlaybackState.Playing;
public bool IsPaused => outputDevice?.PlaybackState == PlaybackState.Paused;


public Ogg(){}

public void Play(string SourcePath){
  _sourcePath = SourcePath;

  if(outputDevice == null){
    // Use NVorbis to read .ogg file
    var vorbisReader = new VorbisReader(SourcePath);

    // Convierte el archivo .ogg a un formato que NAudio pueda manejar
    audioFile = new VorbisWaveReader(vorbisReader);

    // The audio will plays using NAudio in its own thread
    outputDevice = new WaveOutEvent();
    outputDevice.Init(audioFile);
  }

  if (IsPaused || outputDevice.PlaybackState == PlaybackState.Stopped)
    outputDevice.Play();

}

public void Pause() {
  if (IsPlaying)
      outputDevice.Pause();
  System.Console.WriteLine(audioFile.CurrentTime);
}

public void Stop() {
  outputDevice?.Stop();
  audioFile?.Dispose();
  outputDevice?.Dispose();
  audioFile = null;
  outputDevice = null;
}


}
