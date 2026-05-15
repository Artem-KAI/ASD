using lvl1.Models;
using lvl1.Services;
using System.Text;

namespace lvl1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student[] students = new Student[20]
            {
                new Student("Абрамов", "Іван", "Петрович", 101, true),
                new Student("Бойко", "Олег", "Сидорович", 105, false),
                new Student("Васильєв", "Андрій", "Ігорович", 110, true),
                new Student("Гнатюк", "Марія", "Олегівна", 115, true),
                new Student("Данилюк", "Артем", "Сергійович", 120, false),
                new Student("Єгоров", "Максим", "Юрійович", 125, true),
                new Student("Живко", "Юлія", "Павлівна", 130, true),
                new Student("Зінченко", "Денис", "Андрійович", 135, false),
                new Student("Ільїн", "Роман", "Миколайович", 140, true),
                new Student("Коваль", "Анна", "Вікторівна", 145, true),
                new Student("Лимар", "Павло", "Борисович", 150, false),
                new Student("Мороз", "Степан", "Іванович", 155, true),
                new Student("Новак", "Олена", "Петрівна", 160, true),
                new Student("Олійник", "Дмитро", "Сергійович", 165, false),
                new Student("Павлюк", "Ігор", "Михайлович", 170, true),
                new Student("Рибак", "Світлана", "Олегівна", 175, true),
                new Student("Савченко", "Кирило", "Ярославович", 180, false),
                new Student("Ткач", "Вадим", "Петрович", 185, true),
                new Student("Усенко", "Богдан", "Дмитрович", 190, true),
                new Student("Федоренко", "Назар", "Леонідович", 195, false)
            };

            Console.WriteLine("=== СПИСОК СТУДЕНТІВ ===");
            foreach (var s in students) Console.WriteLine(s);

            Console.Write("\nВведіть номер залікової книжки для пошуку: ");
            if (int.TryParse(Console.ReadLine(), out int searchKey))
            {
                int index = SearchService.InterpolationSearch(students, searchKey);

                if (index != -1)
                {
                    Student found = students[index];
                    Console.WriteLine($"\nСтудент знайдений: {found.LastName} {found.FirstName}");

                    if (found.HasMilitaryTraining)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("РЕЗУЛЬТАТ: Цей студент ПРОХОДИТЬ військову підготовку.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("РЕЗУЛЬТАТ: Цей студент НЕ проходить військову підготовку.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nРЕЗУЛЬТАТ: Студента з таким номером заліковки не знайдено.");
                    Console.ResetColor();
                }
            }
        }
    }
}