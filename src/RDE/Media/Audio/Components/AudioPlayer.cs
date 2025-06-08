using RDE.Core.Logs;
using System.IO;
using System;
namespace RDE.Media.Audio;

public sealed class AudioPlayer{

  private Mp3 mp3 = new();
  private Wav wav = new();
  private Ogg ogg = new();
  private Flac flac = new();

  ///<summary>
  ///Thats the file format that will use to read the Audio File
  ///</summary>
  private AudioFormat _format;

  public AudioPlayer(AudioSource? src = default) => source = src;
  public Log DataLog = new();
  public AudioSource? source = new();

  public Log Play() => PlayAudio();
  public Log Pause() => PauseAudio();
  public Log Stop() => StopAudio();

  private Log PlayAudio(){
    if(source == null) {
      DataLog.content = "The source is empty";
      return DataLog;
    }

    // Verify if the file exists
    if (!File.Exists(source.SourcePath)) {
      DataLog.content = $"The \"{source.SourcePath}\" doesn't exists";
      return DataLog;
    }

    _format = source.Format;

    if(_format == AudioFormat.None){
      DataLog.content = "The audio can't be reconozited";
      return DataLog;
    }


    // Play the audio if the source is mp3
    if(_format == AudioFormat.MP3){
      mp3.Play(source.SourcePath);
      DataLog = mp3.Log;
    }

    // Play the audio if the source is ogg
    else if(_format == AudioFormat.OGG){
      ogg.Play(source.SourcePath);
      DataLog = ogg.Log;
    }

    // Play the audio if the source is flac
    else if(_format == AudioFormat.FLAC){
      return flac.Play(source.SourcePath);
      // DataLog = flac.Log;
    }

    // Play the audio if the source is wav
    else if(_format == AudioFormat.WAV){
      wav.Play(source.SourcePath);
      DataLog = wav.Log;
    }

    return DataLog;
  }


  private Log PauseAudio(){
    if(_format == AudioFormat.OGG){
      ogg.Pause();
      DataLog = ogg.Log;
    }
    return DataLog;
  }

  private Log StopAudio(){
    if(_format == AudioFormat.OGG){
      ogg.Stop();
      DataLog = ogg.Log;
    }
    return DataLog;
  }
}
