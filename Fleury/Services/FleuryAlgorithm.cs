using Fleury.Models;

namespace Fleury.Services;

public static class FleuryAlgorithm
{
    public static List<int> FindEulerianPath(List<Node> nodes)
    {
        if (EulerGraphService.IsEulerian(nodes) == EulerianType.NotEulerian)
            return new List<int>();

        var path = new List<int>();
        var edges = BuildEdgeList(nodes);

        Node startNode = nodes.FirstOrDefault(n => n.ConnectedTo.Count % 2 == 1) ?? nodes[0]; // Start at a node of odd degree if any, otherwise start at any node

        TraverseGraph(startNode, edges, path, nodes);

        return path;
    }

    private static void TraverseGraph(Node current, List<Tuple<int, int>> edges, List<int> path, List<Node> nodes)
    {
        path.Add(current.Id);

        foreach (var edge in edges.ToList()) // ToList creates a copy so we can modify the original list while iterating
        {
            if (edge.Item1 == current.Id || edge.Item2 == current.Id)
            {
                edges.Remove(edge); // Remove the edge from the graph

                var nextNodeId = edge.Item1 == current.Id ? edge.Item2 : edge.Item1;
                var nextNode = nodes.First(n => n.Id == nextNodeId);

                TraverseGraph(nextNode, edges, path, nodes);
                break; // Break after the first valid move
            }
        }
    }

    private static List<Tuple<int, int>> BuildEdgeList(List<Node> nodes)
    {
        var edges = new List<Tuple<int, int>>();

        foreach (var node in nodes)
        {
            foreach (var connectedId in node.ConnectedTo)
            {
                var edge = new Tuple<int, int>(node.Id, connectedId);
                if (!edges.Contains(edge) && !edges.Contains(Tuple.Create(connectedId, node.Id))) // Avoid adding duplicate edges
                {
                    edges.Add(edge);
                }
            }
        }

        return edges;
    }
}
