using Fleury.Models;

public static class NodeService
{
    public static event Action OnGraphUpdated;

    private static List<Node> nodes = [
        new Node { Id = 1, X = 362, Y = 280, R = 35, Fill="#1aaee5" },
        new Node { Id = 2, X = 266, Y = 232, R = 15, Fill="#04dcd2" },
        new Node { Id = 3, X = 325, Y = 299, R = 35, Fill="#1aaee5" },
        new Node { Id = 4, X = 474, Y = 123, R = 15, Fill="#04dcd2" },
        new Node { Id = 5, X = 462, Y = 258, R = 35, Fill="#1aaee5" }
    ];

    public static List<Node> GetAllNodes() => nodes;

    public static void AddNode(Node node)
    {
        nodes.Add(node);
        OnGraphUpdated?.Invoke();
    }

    public static void DeleteNode(Node node)
    {
        nodes.Remove(node);
        OnGraphUpdated?.Invoke();
    }

    public static void ConnectNodes(Node node1, Node node2)
    {
        if (node1.Id != node2.Id
            && !node1.ConnectedTo.Contains(node2.Id)
            && !node2.ConnectedTo.Contains(node1.Id))
        {
            node1.ConnectedTo.Add(node2.Id);
            node2.ConnectedTo.Add(node1.Id);

            //if (node1.Id < node2.Id)
            //    node1.ConnectedTo.Add(node2.Id);
            //else
            //    node2.ConnectedTo.Add(node1.Id);
            OnGraphUpdated?.Invoke();
        }
    }
}
