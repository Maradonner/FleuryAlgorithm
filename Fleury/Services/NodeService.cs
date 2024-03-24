using Fleury.Models;

public static class NodeService
{
    public static event Action OnGraphUpdated;

    private static List<Node> nodes = [];

    public static List<Node> GetAllNodes() => nodes;

    public static void InitNodes(List<Node> initNodes)
    {
        if (initNodes == null)
            nodes = [];
        else
            nodes = [..initNodes];
    }

    public static void AddNode(Node node)
    {
        nodes.Add(node);
        OnGraphUpdated?.Invoke();
    }

    public static void DeleteNode(Node node)
    {
        foreach (var n in nodes)
        {
            n.ConnectedTo.Remove(node.Id);
        }

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

            OnGraphUpdated?.Invoke();
        }
    }

    public static void DisconnectNodes(Node node1, Node node2)
    {
        node1.ConnectedTo.Remove(node2.Id);
        node2.ConnectedTo.Remove(node1.Id);
        OnGraphUpdated?.Invoke();
    }
}
