namespace Kelly_M2E;

public class Output
{
    public List<string> Words { get; set; }
    public string Definition { get; set; }
    public List<Output> Children { get; set; } = new();
}