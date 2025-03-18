using System.IO;

namespace Rogie {
    class Program {
        static string path { get; set; } = string.Empty;
        public static string FolderPath { get => path; }       
        
        static void Main(string[] args) {
            path = Directory.GetCurrentDirectory();
            MainMenu mainMenu = new();
        }
    }

}
