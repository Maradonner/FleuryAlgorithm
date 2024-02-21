namespace Fleury.Services;

public static class FleuryAlgorithm
{
    public static void FindWay()
    {
        // Let us first create and test
        // graphs shown in above figure
        Graph g1 = new Graph(4);
        g1.AddEdge(0, 1);
        g1.AddEdge(0, 2);
        g1.AddEdge(1, 2);
        g1.AddEdge(2, 3);
        g1.PrintEulerTour();

        Graph g2 = new Graph(3);
        g2.AddEdge(0, 1);
        g2.AddEdge(1, 2);
        g2.AddEdge(2, 0);
        g2.PrintEulerTour();

        Graph g3 = new Graph(5);
        g3.AddEdge(1, 0);
        g3.AddEdge(0, 2);
        g3.AddEdge(2, 1);
        g3.AddEdge(0, 3);
        g3.AddEdge(3, 4);
        g3.AddEdge(3, 2);
        g3.AddEdge(3, 1);
        g3.AddEdge(2, 4);
        g3.PrintEulerTour();
    }
}
