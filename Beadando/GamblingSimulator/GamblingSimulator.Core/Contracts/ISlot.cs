using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core;

public interface ISlot
{
    string Name { get; }
    SlotResult Spin(long bet, int length);
}