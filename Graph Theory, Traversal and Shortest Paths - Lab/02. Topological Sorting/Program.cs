namespace _02._Topological_Sorting
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes);

            dependencies = ExtractDependancies(graph);

            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child] -= 1;
                }
            }

            if (dependencies.Count == 0)
            {
                Console.WriteLine($"Topogical sorting: {string.Join(", ", sorted)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static Dictionary<string, int> ExtractDependancies(Dictionary<string, List<string>> graph)
        {

            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (var ch in children)
                {
                    if (!result.ContainsKey(ch))
                    {
                        result[ch] = 1;
                    }
                    else
                    {
                        result[ch]++;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int nodes)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < nodes; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                var key = parts[0];

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split(", ").ToList();
                    result[key] = children;
                }
            }

            return result;
        }
    }
}