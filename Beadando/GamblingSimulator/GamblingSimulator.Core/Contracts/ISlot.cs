using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core;

public interface ISlot
{
    SlotResult Spin(long bet, int length);
}