namespace Fleury.Models;

public class GraphInfo
{
    public int NumberOfVertices { get; set; }
    public int NumberOfEdges { get; set; }
    public bool IsConnected { get; set; }
    public int NumberOfConnectedComponents { get; set; }
    public List<int> DegreesOfVertices { get; set; } = new List<int>();
    public int NumberOfVerticesOfOddDegree { get; set; }
    public bool IsUnicursal { get; set; }
    public string FleuryPath { get; set; }
}
