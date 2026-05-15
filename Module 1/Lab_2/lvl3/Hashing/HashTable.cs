namespace lvl3.Hashing;

using lvl3.Models;

class HashTable
{
    private readonly LinkedList<Square>[] table;
    private readonly int size;

    public HashTable(int size)
    {
        this.size = size;
        table = new LinkedList<Square>[size];

        for (int i = 0; i < size; i++)
            table[i] = new LinkedList<Square>();
    }

    private int HashFunction(double key)
    {
        int k = (int)Math.Floor(key);
        k = Math.Abs(k);
        return k % size;
    }

    public bool Insert(Square square)
    {
        int index = HashFunction(square.Perimeter());
        table[index].AddLast(square);
        return true;
    }

    // видалити всі квадрати, площа яких менша за задану 
    public int DeleteByAreaLessThan(double DeletedArea)
    {
        int removed = 0;

        for (int i = 0; i < size; i++)
        {
            var node = table[i].First;
            while (node != null)
            {
                var next = node.Next;

                if (node.Value.Area() < DeletedArea)
                {
                    table[i].Remove(node);
                    removed++;
                }

                node = next;
            }
        }

        return removed;
    }
     
    public void Display(string title)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n {title} ");
        Console.WriteLine("{0,-5} | {1}", "Поз", "Ключ(P) -> Елементи");
        Console.WriteLine(new string('-', 120));
        Console.ResetColor();   

        for (int i = 0; i < size; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[{0:000}] | ", i);
            Console.ResetColor();

            if (table[i].Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Позицiя вільна");
                Console.ResetColor();
                continue;
            }

            foreach (var sq in table[i])
            {   Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"P={sq.Perimeter():F2} => {sq}   ||   ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('-', 120));
        Console.ResetColor();
    }
}