using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.View;

public class SlotRenderer : ISlotRenderer
{
    public void Render(IEnumerable<SlotState> states)
    {
        foreach (var state in states)
        {
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine($"{state.Row[0]} {state.Row[1]} {state.Row[2]}");
            
        }
    }
    
    
}