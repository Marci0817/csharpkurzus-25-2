using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Contracts;

public interface ISlotRenderer
{
    void Render(IEnumerable<SlotResult> states);
}

