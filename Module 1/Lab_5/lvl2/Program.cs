using lvl2.BST;
using lvl2.Models;
using System.Text;

namespace Lab5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            BinarySearchTree tree = new BinarySearchTree();

            var studentsData = new List<Student>
            {
                new Student("Бойко", "Олег", "Сидорович", 105, false),
                new Student("Абрамов", "Іван", "Петрович", 101, true),
                new Student("Гнатюк", "Марія", "Олегівна", 115, true),
                new Student("Коваль", "Анна", "Вікторівна", 145, true),
                new Student("Данилюк", "Артем", "Сергійович", 120, false),
                new Student("Новак", "Олена", "Петрівна", 160, true),
                new Student("Мороз", "Степан", "Іванович", 155, true),
                new Student("Ткач", "Вадим", "Олександрович", 185, true),
                new Student("Усенко", "Богдан", "Дмитрович", 190, true),
                new Student("Савченко", "Кирило", "Ярославович", 180, false),
                new Student("Ільїн", "Роман", "Миколайович", 140, true),
                new Student("Живко", "Юлія", "Павлівна", 130, true),
                new Student("Зінченко", "Денис", "Андрійович", 135, false),
                new Student("Павлюк", "Ігор", "Михайлович", 170, true),
                new Student("Рибак", "Світлана", "Олегівна", 175, true),
                new Student("Лимар", "Павло", "Борисович", 150, false),
                new Student("Федоренко", "Назар", "Леонідович", 195, false),
                new Student("Васильєв", "Андрій", "Ігорович", 110, true),
                new Student("Єгоров", "Максим", "Юрійович", 125, true),
                new Student("Ткаченко", "Дмитро", "Петрович", 200, true)
            };

            Console.WriteLine("=== СПИСОК СТУДЕНТІВ ===");
            foreach (var s in studentsData) 
                Console.WriteLine(s);

            foreach (var s in studentsData)
            {
                tree.Insert(s);
            }

            Console.WriteLine(">>> БІНАРНЕ ДЕРЕВО ПОШУКУ СТВОРЕНО <<<");
            Console.WriteLine("Ключ пошуку: Ім'я ");
            Console.WriteLine(new string('-', 60));

            Console.Write("\nВведіть ім'я студента для пошуку: ");
            string searchName = Console.ReadLine();

            Node result = tree.Search(searchName);

            if (result != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВУЗОЛ ЗНАЙДЕНО:");
                Console.WriteLine(result.Data);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nСтудента з таким ім'ям не знайдено.");
                Console.ResetColor();
            }

            Console.WriteLine("\nВиконання ротації вліво для кореня");
            tree.RotateLeft();
            Console.WriteLine("Коренем став вузол: " + tree.Root.Data.FirstName);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу");
            Console.ReadKey();
        }
    }
}