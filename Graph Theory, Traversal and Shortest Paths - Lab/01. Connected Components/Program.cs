namespace _01._Connected_Components
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var graph = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                var children = new List<int>();

                foreach (string child in input)
                {
                    children.Add(int.Parse(child));
                }

                graph.Add(children);
            }

            var connectedComponents = FindConnectedComponents(graph);

            foreach (var component in connectedComponents)
            {
                Console.WriteLine("Connected component: " + string.Join(" ", component));
            }
        }

        static List<List<int>> FindConnectedComponents(List<List<int>> graph)
        {
            int n = graph.Count;
            var visited = new bool[n];
            var components = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    var component = new List<int>();
                    DFS(graph, i, visited, component);
                    components.Add(component);
                }
            }

            return components;
        }

        static void DFS(List<List<int>> graph, int node, bool[] visited, List<int> component)
        {
            visited[node] = true;
            component.Add(node);

            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    DFS(graph, child, visited, component);
                }
            }
        }
    }

}
