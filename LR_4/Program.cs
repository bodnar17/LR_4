using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введiть шлях до файлу: ");
        string fileName = Console.ReadLine(); // отримуємо ім'я файлу з консолі
        string outputFileName = Path.ChangeExtension(fileName, ".tmp"); // створюємо нове ім'я файлу з розширенням .tmp

        Dictionary<char, int> charFrequencies = new Dictionary<char, int>();

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    foreach (char c in line)
                    {
                        if (charFrequencies.ContainsKey(c))
                        {
                            charFrequencies[c]++;
                        }
                        else
                        {
                            charFrequencies[c] = 1;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (var pair in charFrequencies)
                {
                    writer.WriteLine($"Символ '{pair.Key}': {pair.Value} разiв");
                }
            }

            Console.WriteLine($"Результат збережено у файлi {outputFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
