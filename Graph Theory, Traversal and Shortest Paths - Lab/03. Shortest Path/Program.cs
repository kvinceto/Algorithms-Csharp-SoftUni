namespace _03._Shortest_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int source = input[0];
                int destination = input[1];

                if (!graph.ContainsKey(source))
                    graph[source] = new List<Edge>();

                if (!graph.ContainsKey(destination))
                    graph[destination] = new List<Edge>();

                graph[source].Add(new Edge(destination));
                graph[destination].Add(new Edge(source));
            }

            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            var shortestPath = FindShortestPath(graph, startNode, endNode);

            if (shortestPath == null)
            {
                Console.WriteLine("No path found.");
            }
            else
            {
                Console.WriteLine("Shortest path length is: " + shortestPath.Length);
                Console.WriteLine(string.Join(" ", shortestPath.Path));
            }
        }

        static ShortestPathResult FindShortestPath(Dictionary<int, List<Edge>> graph, int startNode, int endNode)
        {
            var queue = new PriorityQueue<Node>();
            var distances = new Dictionary<int, int>();
            var previous = new Dictionary<int, int>();

            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
                previous[node] = -1;
            }

            distances[startNode] = 0;
            queue.Enqueue(new Node(startNode, 0));

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Id == endNode)
                    break;

                if (currentNode.Distance > distances[currentNode.Id])
                    continue;

                foreach (var neighbor in graph[currentNode.Id])
                {
                    int newDistance = currentNode.Distance + 1;

                    if (newDistance < distances[neighbor.Id])
                    {
                        distances[neighbor.Id] = newDistance;
                        previous[neighbor.Id] = currentNode.Id;
                        queue.Enqueue(new Node(neighbor.Id, newDistance));
                    }
                }
            }

            if (previous[endNode] == -1)
                return null;

            var path = new List<int>();
            int current = endNode;

            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();

            return new ShortestPathResult(distances[endNode], path);
        }
    }

    class Edge
    {
        public int Id { get; }

        public Edge(int id)
        {
            Id = id;
        }
    }

    class Node : IComparable<Node>
    {
        public int Id { get; }
        public int Distance { get; }

        public Node(int id, int distance)
        {
            Id = id;
            Distance = distance;
        }

        public int CompareTo(Node other)
        {
            return Distance.CompareTo(other.Distance);
        }
    }

    class ShortestPathResult
    {
        public int Length { get; }
        public List<int> Path { get; }

        public ShortestPathResult(int length, List<int> path)
        {
            Length = length;
            Path = path;
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;

        public int Count => heap.Count;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int currentIndex = heap.Count - 1;

            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;

                if (heap[currentIndex].CompareTo(heap[parentIndex]) >= 0)
                    break;

                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Priority queue is empty.");

            T root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int currentIndex = 0;

            while (currentIndex < heap.Count)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;

                if (leftChildIndex >= heap.Count)
                    break;

                int smallerChildIndex = leftChildIndex;

                if (rightChildIndex < heap.Count && heap[rightChildIndex].CompareTo(heap[leftChildIndex]) < 0)
                    smallerChildIndex = rightChildIndex;

                if (heap[currentIndex].CompareTo(heap[smallerChildIndex]) <= 0)
                    break;

                Swap(currentIndex, smallerChildIndex);
                currentIndex = smallerChildIndex;
            }

            return root;
        }

        private void Swap(int index1, int index2)
        {
            T temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }

}
