using lvl1.Services;
using System.Text;
using lvl1.Modoels;

namespace lvl1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student[] students = {
                new Student("Іваненко", "Олег", "KB-001", "IT-21"),
                new Student("Петренко", "Анна", "KB-005", "AC-11"),
                new Student("Сидоренко", "Ігор", "KB-003", "IT-21"),
                new Student("Коваль", "Марія", "KB-002", "BB-05"),
                new Student("Ткаченко", "Максим", "KB-004", "AC-11")
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--->>> Масив до сортування <<<---");
            Console.ResetColor();
            PrintTable(students);

            BubbleSorter.Sort(students);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--->>> Масив після сортування (БУЛЬБАШКА, ЗА ГРУПОЮ) <<<---");
            Console.ResetColor();
            PrintTable(students); 
            
        }

        static void PrintTable(Student[] students)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"| {"Група",-8} | {"Квиток",-10} | {"Прізвище та ім'я",-22} |");
            Console.WriteLine(new string('-', 50));
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}