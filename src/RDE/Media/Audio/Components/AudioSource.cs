using System;
namespace RDE.Media.Audio;

public class AudioSource{
  protected string _sourcePath = String.Empty;

  ///<summary>
  ///Thats the file format that will use to read the Audio File
  ///</summary>
  public AudioFormat Format;
  public string SourcePath { get => _sourcePath; set => _sourcePath = SetSourcePath(value); }

  public AudioSource(){}
  public AudioSource(string SourcePath) {
    _sourcePath = SourcePath;
    Format = AudioHeader.GetFormat(_sourcePath);
  }

  private string SetSourcePath(string _path){
    Format = AudioHeader.GetFormat(_path);
    return _path;
  }

}

