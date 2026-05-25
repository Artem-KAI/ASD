using System;
using System.Collections.Generic;
using System.Linq;

namespace lvl1
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string filePath = "words_variant5.txt";
             
            var initialWords = new List<string>
            {
                "+123",         // Правильно: +, цифри
                "+456ABC",      // Правильно: +, цифри, літери A-Z
                "+0Z",          // Правильно: +, одна цифра, одна літера
                "123ABC",       // Неправильно: відсутній +
                "+ABC",         // Неправильно: відсутні обов'язкові цифри
                "+123abc",      // Неправильно: літери в нижньому регістрі
                "+123ABC45",    // Неправильно: після літер знову йдуть цифри
                "test_word"     // Неправильно
            };

            try
            {  
                FileHandler.CreateFileWithWords(filePath, initialWords);

                // Регулярний  
                // ^       - початок слова
                // \+      - символ '+'
                // \d+     - одна або більше цифр (0-9)
                // [A-Z]* - нуль або більше великих літер (A-Z)
                // $       - кінець слова
                string pattern = @"^\+\d+[A-Z]*$";

                var matcher = new RegexMatcher(pattern);
                 
                var wordsFromFile = FileHandler.ReadWordsFromFile(filePath);
                var matchedWords = matcher.FindMatchingWords(wordsFromFile).ToList();
                 
                Console.WriteLine("\n--- РЕЗУЛЬТАТИ ПОШУКУ (Рівень 1, Варіант 5) ---");
                Console.WriteLine($"Регулярний вираз: {pattern}");
                Console.WriteLine($"Знайдено відповідних слів: {matchedWords.Count}\n");

                foreach (var word in matchedWords)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[ЗНАЙДЕНО] {word}");
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ПОМИЛКА] {ex.Message}");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}