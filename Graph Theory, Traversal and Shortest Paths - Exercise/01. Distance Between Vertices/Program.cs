using System;

namespace _01._Distance_Between_Vertices
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int P = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                int vertex = int.Parse(input[0]);

                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<int>();
                }

                if (input.Length > 1)
                {
                    string[] edges = input[1].Split(" ");
                    foreach (string edge in edges)
                    {
                        graph[vertex].Add(int.Parse(edge));
                    }
                }
            }

            for (int i = 0; i < P; i++)
            {
                string[] pair = Console.ReadLine().Split("-");
                int start = int.Parse(pair[0]);
                int end = int.Parse(pair[1]);

                int distance = FindShortestDistance(graph, start, end);
                Console.WriteLine($"{{{start}, {end}}} -> {distance}");
            }
        }

        static int FindShortestDistance(Dictionary<int, List<int>> graph, int start, int end)
        {
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
                return -1;

            var queue = new Queue<int>();
            var distances = new Dictionary<int, int>();

            queue.Enqueue(start);
            distances[start] = 0;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == end)
                {
                    return distances[current];
                }

                foreach (int neighbor in graph[current])
                {
                    if (!distances.ContainsKey(neighbor))
                    {
                        distances[neighbor] = distances[current] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return -1;
        }
    }

}
