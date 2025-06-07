using System;
using System.IO;

namespace RDE.Core;


public class Application {

  // Path from the Game is Execute
  private static string _path { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
  public static string Path { get => _path; }


  // Path from your csharp project
  private static string _projectPath = $@"{Environment.CurrentDirectory}\";


  // Path that use the engine to save the assets when the project will build's
  private static string _export_D_Path = $@"{_path}\bin\Debug\net9.0\";
  private static string _export_R_Path = $@"{_path}\bin\Release\net9.0\";


  // Path that game get the Assets
  private static string _assetsPath = _projectPath + @"assets";
  public static string AssetsPath { get => _assetsPath; }

  // Modes to define how and where the asssets will read's
  private static DebugMode _debugMode = DebugMode.INTERNAL;
  public static DebugMode DebugMode { get => _debugMode; set => _debugMode = value; }


  public static void SetDebugMode(DebugMode dm) => _debugMode = dm;

  private static void ExportAssets(){
    string _exportAssetsPath = String.Empty;

    if(_debugMode == DebugMode.BUILD_D){
      _exportAssetsPath = _export_D_Path;
    }
    else if(_debugMode == DebugMode.BUILD_R){
      _exportAssetsPath = _export_R_Path;
    }


    if(!Directory.Exists(_exportAssetsPath))
        Directory.CreateDirectory(_exportAssetsPath);

    try {
      CopyAssetsToBuild(AssetsPath, _exportAssetsPath);
      _assetsPath = _exportAssetsPath;
    }
    catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
  }

  static void CopyAssetsToBuild(string origen, string destino) {
    // Create the directory if doesn't exists
    Directory.CreateDirectory(destino);

    // Copy all the file's from the current path
    foreach (string archivo in Directory.GetFiles(origen)) {
      string nombreArchivo = System.IO.Path.GetFileName(archivo);
      string destinoArchivo = System.IO.Path.Combine(destino, nombreArchivo);
      File.Copy(archivo, destinoArchivo, overwrite: true); // Sobrescribe si existe
    }

    // Copy file's using recursive method
    foreach (string subDir in Directory.GetDirectories(origen)) {
      string nombreSubDir = System.IO.Path.GetFileName(subDir);
      string destinoSubDir = System.IO.Path.Combine(destino, nombreSubDir);
      CopyAssetsToBuild(subDir, destinoSubDir);
    }
  }

}
