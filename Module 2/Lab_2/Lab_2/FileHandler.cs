using System;
using System.Collections.Generic;
using System.IO;

namespace lvl1
{
    public static class FileHandler
    {
        /// <summary>
        /// Створює текстовий файл і записує в нього масив слів.
        /// </summary>
        public static void CreateFileWithWords(string filePath, IEnumerable<string> words)
        {
            File.WriteAllLines(filePath, words);
            Console.WriteLine($"[ФАЙЛ] Створено за шляхом: {Path.GetFullPath(filePath)}");
        }

        /// <summary>
        /// Зчитує всі рядки з файлу.
        /// </summary>
        public static IEnumerable<string> ReadWordsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не знайдено: {filePath}");
            }

            return File.ReadAllLines(filePath);
        }
    }
}