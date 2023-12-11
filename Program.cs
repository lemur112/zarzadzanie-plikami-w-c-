using System.IO;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wskaż ścieżkę pliku:");
        string path = Console.ReadLine();

        if(!path.Contains(".txt"))
        {
          DirectoryInfo di = new DirectoryInfo(path);
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }
            return;
        }

        if (File.Exists(path))
        {
            Console.Write(File.ReadAllText(path));
        }
        else
        {
            Console.WriteLine("Podany plik nie istnieje. Tworzenie nowego pliku tekstowego...");
            File.Create(path).Close();

            Console.WriteLine("Stworzono nowy plik txt w lokalizacji " + path );

            Console.WriteLine("\n Wprowadź zawartość nowego pliku: \n aby zakończyć tryb edycji wprowadź END;;");

          

            string line = Console.ReadLine();
            string data = "";
            while (line != "END;;")
            {
                data += line + "\n";
                line = Console.ReadLine();
            }
           File.AppendAllText(path, data);
        }
    }
}