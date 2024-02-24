using Fleury.Models;

namespace Fleury.Services;

public static class EulerGraphService
{
    public static bool IsEulerGraph(List<Node> nodes)
    {
        // Check if all vertices are connected
        if (!IsConnectedGraph(nodes))
            return false;

        // Check if all vertices have an even degree
        return nodes.All(plant => plant.ConnectedTo.Count % 2 == 0);
    }

    private static bool IsConnectedGraph(List<Node> nodes)
    {
        if (nodes.Count == 0)
            return true;

        var visited = new HashSet<int>();
        DepthFirstSearch(nodes, nodes[0], visited);

        // Graph is connected if all vertices are visited
        return visited.Count == nodes.Count;
    }

    private static void DepthFirstSearch(List<Node> nodes, Node current, HashSet<int> visited)
    {
        visited.Add(current.Id);

        foreach (var connectedId in current.ConnectedTo)
        {
            if (!visited.Contains(connectedId))
            {
                var next = nodes.FirstOrDefault(p => p.Id == connectedId);
                if (next != null)
                {
                    DepthFirstSearch(nodes, next, visited);
                }
            }
        }
    }
}
