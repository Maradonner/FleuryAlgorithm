using Fleury.Models;

namespace Fleury.Services;

public static class EulerGraphService
{
    public static EulerianType IsEulerian(List<Node> nodes)
    {
        if (!IsConnectedGraph(nodes))
            return EulerianType.NotEulerian;

        int oddDegreeCount = nodes.Count(node => node.ConnectedTo.Count % 2 != 0);

        if (oddDegreeCount > 2)
            return EulerianType.NotEulerian;
        else if (oddDegreeCount == 2)
            return EulerianType.SemiEulerian;
        else
            return EulerianType.Eulerian;
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
