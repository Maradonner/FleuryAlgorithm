namespace Fleury.Models;

public class Node
{
    public int Id { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double R { get; set; }
    public string Fill { get; set; } = "#333";
    public List<int> ConnectedTo { get; set; } = [];
    public bool IsSelected { get; set; } = false;
}
