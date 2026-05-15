using System.Collections.Generic;

namespace lvl2
{
    public class Graph
    {
        public Dictionary<Node, List<Node>> AdjacencyList { get; private set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<Node, List<Node>>();
        }

        public void AddNode(Node node)
        {
            if (!AdjacencyList.ContainsKey(node))
            {
                AdjacencyList[node] = new List<Node>();
            }
        }

        public void AddEdge(Node from, Node to)
        {
            if (AdjacencyList.ContainsKey(from) && AdjacencyList.ContainsKey(to))
            {
                AdjacencyList[from].Add(to);
            }
        }

        public List<Node> BFS(Node start, Node target)
        {
            var queue = new Queue<Node>();
            var visited = new HashSet<Node>();
            var parentMap = new Dictionary<Node, Node?>();

            queue.Enqueue(start);
            visited.Add(start);
            parentMap[start] = null;

            bool isFound = false;

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (current.Equals(target))
                {
                    isFound = true;
                    break;
                }

                foreach (Node neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parentMap[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            var path = new List<Node>();

            if (isFound)
            {
                Node? currentPathNode = target;

                while (currentPathNode.HasValue)
                {
                    path.Add(currentPathNode.Value);
                    currentPathNode = parentMap[currentPathNode.Value];
                }

                path.Reverse();
            }

            return path;
        }
    }
}