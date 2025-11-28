using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.View;

public class SlotRenderer : ISlotRenderer
{
    public void Render(IEnumerable<SlotResult> states)
    {
        foreach (var state in states)
        {
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine($"{state.Symbols[0]} {state.Symbols[1]} {state.Symbols[2]}");
        }
    }
}

