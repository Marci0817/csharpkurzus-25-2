namespace GamblingSimulator.Core.Models;

public class PlayerState
{
    public string Name = "unknown";
    public long Balance { get; set; } = 1000;
    public List<SlotResult> History { get; set; } = [];
}

