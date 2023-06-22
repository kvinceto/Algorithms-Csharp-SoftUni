namespace _01._Connected_Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            if (nodes <= 0 )
            {
                return;
            }

            graph = new List<int>[nodes];
            visited = new bool[nodes];

            for (int i = 0; i < nodes; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                {
                    graph[i] = new List<int>();
                    continue;
                }

                var children = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                graph[i] = children;
            }

            Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                var component = new List<int>();
                DFS(node, component);
                results[node] = component;
            }

            foreach (var component in results.Where(r => r.Value.Count > 0))
            {
                Console.WriteLine($" Connected components: {string.Join(" ", component.Value)}");
            }
        }

        private static void DFS(int node, List<int> components)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, components);
            }

            components.Add(node);
        }
    }
}
