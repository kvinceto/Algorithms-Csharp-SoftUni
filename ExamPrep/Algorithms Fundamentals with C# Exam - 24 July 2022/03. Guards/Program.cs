using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Guards
{
    public class Program
    {

        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            int edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes + 1];
            visited = new bool[nodes + 1];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];

                graph[from].Add(to);
            }

            int startNode = int.Parse(Console.ReadLine());

            DFS(startNode);

            Print();
        }

        private static void Print()
        {
            var sb = new StringBuilder();

            for (int node = 1; node < visited.Length; node++)
            {
                if (!visited[node])
                {
                    sb.Append($"{node} ");
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
