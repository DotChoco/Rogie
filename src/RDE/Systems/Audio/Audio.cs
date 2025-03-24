using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using NVorbis;
using RDE.Structs.Enums;

namespace RDE;

public sealed class Audio{
    public string SourcePath = string.Empty;
    public AudioFormat Format = AudioFormat.MP3;
    public Audio(){}
    public Audio(string SourcePath)=> this.SourcePath = SourcePath; 
    
    public void Play() => Play(Format);
    
    public void Play(AudioFormat format){
        if(format == AudioFormat.MP3)
            PlayMP3();
        else if(format == AudioFormat.OGG)
            PlayOGG();
        else if(format == AudioFormat.FLAC)
            PlayFLAC();
        else if(format == AudioFormat.WAV)
            PlayWAV();
    }


    private void PlayMP3(){
        if (!File.Exists(SourcePath))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }

        using (var audioFile = new Mp3FileReader(SourcePath))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();

            Console.WriteLine("Reproduciendo MP3... Presiona Enter para detener.");
            Thread.Sleep(audioFile.TotalTime);
            Console.WriteLine(audioFile.TotalTime);
        }
    }

    private void PlayFLAC(){
        if (!File.Exists(SourcePath))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }
        
        try
            {
                using var reader = new NAudio.Flac.FlacReader(SourcePath);
                using var player = new DirectSoundOut();
                player.Init(reader);
                player.Play();

                Console.WriteLine("Now playing with NAudio.Flac back-end, press any key to continue.");
                Thread.Sleep(reader.TotalTime);
                Console.WriteLine(reader.TotalTime);
            }
            catch (Exception ex)
            {
                var foregroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Unable to play with NAudio.Flac back-end: " + ex);
                Console.ForegroundColor = foregroundColor;
            }
    }

    private void PlayOGG(){
        // Verifica si el archivo existe
        if (!File.Exists(SourcePath))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }

        // Usa NVorbis para leer el archivo .ogg
        var vorbisReader = new VorbisReader(SourcePath);

        // Convierte el archivo .ogg a un formato que NAudio pueda manejar
        // var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(vorbisReader.SampleRate, vorbisReader.Channels);
        var audioFile = new VorbisWaveReader(vorbisReader);

        // Reproduce el audio usando NAudio
        using (var outputDevice = new WaveOutEvent()) {
            outputDevice.Init(audioFile);
            outputDevice.Play();

            Console.WriteLine("Reproduciendo archivo .ogg... Presiona Enter para detener.");
            Thread.Sleep(audioFile.TotalTime);
            Console.WriteLine(audioFile.TotalTime);
        }
    }

    private void PlayWAV(){
        using (var audioFile = new AudioFileReader(SourcePath))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();
            
            Console.WriteLine("Reproduciendo sonido WAV... Presiona 'CTRL + C' para salir.");
            Thread.Sleep(audioFile.TotalTime);
            Console.WriteLine(audioFile.TotalTime);
        }
    }

}