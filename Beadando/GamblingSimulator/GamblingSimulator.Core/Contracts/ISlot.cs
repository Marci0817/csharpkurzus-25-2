using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core;

public interface ISlot
{
    IEnumerable<SlotState> Spin(long bet, int length);
}