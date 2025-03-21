using System;
using System.IO;
using Debug = RDE.Debuggin.Debug;

namespace Rogie {
    class Program {
        static string path { get; set; } = string.Empty;
        public static string FolderPath { get => path; }       
        
        static void Main() {
            path = Directory.GetCurrentDirectory();
            // Debug debug = new();
            // debug.InitServer();
            MainMenu mainMenu = new();
            Console.WriteLine("UwU");
        }
    }

}
