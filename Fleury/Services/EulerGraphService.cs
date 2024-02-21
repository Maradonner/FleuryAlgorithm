using Fleury.Models;

namespace Fleury.Services;

public static class EulerGraphService
{
    public static bool IsEulerGraph(Node[] plants)
    {
        // Check if all vertices are connected
        if (!IsConnectedGraph(plants))
            return false;

        // Check if all vertices have an even degree
        return plants.All(plant => plant.ConnectedTo.Count % 2 == 0);
    }

    private static bool IsConnectedGraph(Node[] plants)
    {
        if (plants.Length == 0)
            return true;

        var visited = new HashSet<int>();
        DepthFirstSearch(plants, plants[0], visited);

        // Graph is connected if all vertices are visited
        return visited.Count == plants.Length;
    }

    private static void DepthFirstSearch(Node[] plants, Node current, HashSet<int> visited)
    {
        visited.Add(current.Id);

        foreach (var connectedId in current.ConnectedTo)
        {
            if (!visited.Contains(connectedId))
            {
                var next = plants.FirstOrDefault(p => p.Id == connectedId);
                if (next != null)
                {
                    DepthFirstSearch(plants, next, visited);
                }
            }
        }
    }
}
