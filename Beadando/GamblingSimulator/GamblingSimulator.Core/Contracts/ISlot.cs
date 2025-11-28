using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Contracts;

public interface ISlot
{
    string Name { get; }
    SlotResult Spin(long bet, int length);
}

