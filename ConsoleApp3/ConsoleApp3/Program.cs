using System;
using System.IO;

class Program
{
    static void Main()
    {
        string currentDirectory = @"D:\";

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Joriy katalog: {currentDirectory}");
            Console.WriteLine($"{"Fayl/Papka",-50} {"Hajm"}");
            Console.WriteLine(new string('-', 70));

            try
            {
                DirectoryInfo directory = new DirectoryInfo(currentDirectory);
                foreach (var dir in directory.GetDirectories())
                {
                    Console.WriteLine($"{dir.Name,-50} <PAPKA>");
                }
                foreach (var file in directory.GetFiles())
                {
                    Console.WriteLine($"{file.Name,-50} {file.Length} bayt");
                }

                Console.WriteLine();
                Console.Write("Katalog nomini kiriting ('../' - orqaga qaytish, 'exit' - chiqish): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit") 
                    break;

                if (input == "../") 
                {
                    if (directory.Parent != null)
                    {
                        currentDirectory = directory.Parent.FullName;
                    }
                    else
                    {
                        Console.WriteLine("Siz allaqachon ildiz katalogdasiz. Davom etish uchun biror tugmani bosing...");
                        Console.ReadKey();
                    }
                }
                else 
                {
                    string newPath = Path.Combine(currentDirectory, input);
                    if (Directory.Exists(newPath))
                    {
                        currentDirectory = newPath;
                    }
                    else
                    {
                        Console.WriteLine("Katalog nomi noto‘g‘ri. Qayta urinib ko‘rish uchun biror tugmani bosing...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik yuz berdi: {ex.Message}");
                Console.WriteLine("Davom etish uchun biror tugmani bosing...");
                Console.ReadKey();
            }
        }
    }
}
