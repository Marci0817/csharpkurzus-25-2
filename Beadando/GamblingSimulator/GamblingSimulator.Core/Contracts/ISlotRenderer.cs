using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core;

public interface ISlotRenderer
{
    void Render(IEnumerable<SlotState> states);
}