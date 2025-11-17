using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.View;

public class SlotRenderer : ISlotRenderer
{
    public int Counter { get; set; }
    public void Render(IEnumerable<SlotState> states)
    {
        foreach (var state in states)
        {
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine(Counter++);
        }
    }
}