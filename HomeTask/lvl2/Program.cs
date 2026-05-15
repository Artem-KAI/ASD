using System;
using System.Collections.Generic;

namespace lvl2
{
    internal class Program
    {
        private static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            int[,] maze =
            {
                { 0, 0, 1, 0, 0 },
                { 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 }
            };

            Graph graph = MazeBuilder.BuildGraphFromMaze(maze);

            Node start = new Node(0, 0);
            Node target = new Node(2, 2);

            Console.WriteLine("=== Пошук шляху в лабіринті (BFS) ===\n");
            PrintMaze(maze, start, target);

            List<Node> path = graph.BFS(start, target);

            Console.WriteLine("\n--- Результат ---");

            if (path.Count > 0)
            {
                Console.WriteLine("Шлях успішно знайдено!");
                Console.WriteLine(string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine("Шляху до центру не існує.");
            }

            Console.ReadLine();
        }

        private static void PrintMaze(int[,] maze, Node start, Node target)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Node current = new Node(r, c);

                    if (current.Equals(start))
                    {
                        Console.Write("S ");
                    }
                    else if (current.Equals(target))
                    {
                        Console.Write("T ");
                    }
                    else if (maze[r, c] == 1)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nЛегенда: S - Старт, T - Ціль (центр), # - Кущ, . - Прохід");
        }
    }
}