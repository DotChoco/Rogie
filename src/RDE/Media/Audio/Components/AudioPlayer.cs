using RDE.Core.Logs;
// using System.IO;
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
  bool IsPlaying = false;
  public void Forward(int time){
    if(IsPlaying)
      ogg.Forward(time);
  }
  public void Backward(int time){
    if(IsPlaying)
      ogg.Backward(time);
  }

  private Log PlayAudio(){
    //Extract AudioFormat from FileHeader
    _format = source.Format;

    //Check if the file exists and isn't null string
    DataLog.content = DataLog.FileExists(source.SourcePath);

    if(_format == AudioFormat.None){
      DataLog.content = "The audio can't be reconozited";
      return DataLog;
    }


    // Play the audio if the source is mp3
    if(_format == AudioFormat.MP3){
      mp3.Play(source.SourcePath);
      return mp3.Log;
    }

    // Play the audio if the source is ogg
    else if(_format == AudioFormat.OGG){
      IsPlaying = true;
      ogg.Play(source.SourcePath);
      return ogg.Log;
    }

    // Play the audio if the source is flac
    else if(_format == AudioFormat.FLAC){
      flac.Play(source.SourcePath);
      return flac.Log;
    }

    // Play the audio if the source is wav
    else if(_format == AudioFormat.WAV){
      wav.Play(source.SourcePath);
      return wav.Log;
    }

    return DataLog;
  }


  private Log PauseAudio(){
    IsPlaying = false;
    if(_format == AudioFormat.OGG){
      ogg.Pause();
      DataLog = ogg.Log;
    }
    return DataLog;
  }

  private Log StopAudio(){
    IsPlaying = false;
    if(_format == AudioFormat.OGG){
      ogg.Stop();
      DataLog = ogg.Log;
    }
    return DataLog;
  }
}
