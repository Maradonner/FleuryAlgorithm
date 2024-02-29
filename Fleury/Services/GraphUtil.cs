using Fleury.Models;

namespace Fleury.Services;

public class GraphUtil
{
    public static Graph CreateGraphFromNodes(List<Node> nodes)
    {
        Graph graph = new Graph();

        // Add all nodes to the graph
        foreach (var node in nodes)
        {
            graph.AddNode(node);
        }

        // Add edges based on the ConnectedTo property of each node
        foreach (var node in nodes)
        {
            foreach (var connectedNodeId in node.ConnectedTo)
            {
                // This adds an undirected edge between the current node and each connected node
                graph.AddEdge(node.Id, connectedNodeId);
            }
        }

        return graph;
    }
}
