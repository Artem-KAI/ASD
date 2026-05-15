 
namespace lvl2
{
    public static class MazeBuilder
    {
        public static Graph BuildGraphFromMaze(int[,] maze)
        {
            var graph = new Graph();
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c] == 0)
                    {
                        graph.AddNode(new Node(r, c));
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c] == 0)
                    {
                        Node current = new Node(r, c);

                        if (r > 0 && maze[r - 1, c] == 0)
                        {
                            graph.AddEdge(current, new Node(r - 1, c));
                        }

                        if (r < rows - 1 && maze[r + 1, c] == 0)
                        {
                            graph.AddEdge(current, new Node(r + 1, c));
                        }

                        if (c > 0 && maze[r, c - 1] == 0)
                        {
                            graph.AddEdge(current, new Node(r, c - 1));
                        }

                        if (c < cols - 1 && maze[r, c + 1] == 0)
                        {
                            graph.AddEdge(current, new Node(r, c + 1));
                        }
                    }
                }
            }

            return graph;
        }
    }
}