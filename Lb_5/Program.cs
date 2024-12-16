using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string filePath = "data.txt";

        while (true)
        {
            Console.WriteLine("Виберіть дію:");
            Console.WriteLine("1 - Прочитати дані з файлу");
            Console.WriteLine("2 - Записати дані у файл");
            Console.WriteLine("3 - Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReadFromFile(filePath);
                    break;
                case "2":
                    WriteToFile(filePath);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ReadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Вміст файлу:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Файл не існує.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
        }
    }

    static void WriteToFile(string filePath)
    {
        try
        {
            Console.WriteLine("Введіть текст для запису у файл:");
            string inputText = Console.ReadLine();

            Console.WriteLine("Виберіть режим запису:");
            Console.WriteLine("1 - Перезаписати файл");
            Console.WriteLine("2 - Додати текст до файлу");

            string mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                    File.WriteAllText(filePath, inputText);
                    Console.WriteLine("Файл успішно перезаписано.");
                    break;
                case "2":
                    File.AppendAllText(filePath, inputText + Environment.NewLine);
                    Console.WriteLine("Текст успішно додано до файлу.");
                    break;
                default:
                    Console.WriteLine("Невірний вибір режиму запису.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при записі у файл: {ex.Message}");
        }
    }
}
