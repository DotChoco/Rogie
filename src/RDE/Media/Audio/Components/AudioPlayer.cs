using RDE.Core.Logs;
using System.IO;
namespace RDE.Media.Audio;

public sealed class AudioPlayer{

  private Mp3 mp3 = new();
  private Wav wav = new();
  private Ogg ogg = new();
  private Flac flac = new();
  private AudioHeader _audioHeader = new();

  ///<summary>
  ///Thats the file format that will use to read the Audio File
  ///</summary>
  private AudioFormat _format;

  public AudioPlayer(AudioSource? src = default) => source = src;
  public Log DataLog = new();
  public AudioSource? source = new();

  public Log Play() => PlayAudio();
  // public Log Pause() => PauseAudio();
  // public Log Stop() => StopAudio();
  // public Log Resume() => ResumeAudio();

  private Log PlayAudio(){

  if(source == null)
  {
    DataLog.content = "The source is empty";
    return DataLog;
  }

  // Verify if the file exists
  if (!File.Exists(source.SourcePath)) {
    DataLog.content = $"The \"{source.SourcePath}\" doesn't exists";
    return DataLog;
  }
  // _format = _audioHeader.GetFormat(source.SourcePath);
  var header = _audioHeader.GetFormat(source.SourcePath);
  _format = source.Format;
  // _format = AudioFormat.OGG;


  // Play the audio if the source is mp3
  if(_format == AudioFormat.MP3){
    mp3.BGP = source.BGP;
    mp3.Play(source.SourcePath);
    DataLog = mp3.Log;
  }

  // Play the audio if the source is ogg
  else if(_format == AudioFormat.OGG){
    ogg.BGP = source.BGP;
    ogg.Play(source.SourcePath);
    DataLog = ogg.Log;
  }

  // Play the audio if the source is flac
  else if(_format == AudioFormat.FLAC){
    flac.BGP = source.BGP;
    flac.Play(source.SourcePath);
    DataLog = flac.Log;
  }

  // Play the audio if the source is wav
  else if(_format == AudioFormat.WAV){
    wav.BGP = source.BGP;
    wav.Play(source.SourcePath);
    DataLog = wav.Log;
  }

  return DataLog;
  }









}
