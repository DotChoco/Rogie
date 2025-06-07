using System.IO;
namespace RDE.Media.Audio;

public sealed class AudioHeader{
  public AudioHeader(){}

  public AudioFormat GetFormat(string path){
    byte[] data = File.ReadAllBytes(path);
    if(IsMp3(data)){ return AudioFormat.MP3; }
    if(IsWav(data)){ return AudioFormat.WAV; }
    if(IsOgg(data)){ return AudioFormat.OGG; }
    if(IsFlac(data)){ return AudioFormat.FLAC; }
    return AudioFormat.None;
  }

  private bool IsMp3(byte[] dataBytes){
    return true;
  }


   private bool IsWav(byte[] dataBytes){
    return true;
  }

   private bool IsOgg(byte[] dataBytes){
    return true;
  }

   private bool IsFlac(byte[] dataBytes){
    return true;
  }




}
