using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Storage;

namespace GamblingSimulator.Core.Services
{
    public interface ISlotService
    {
        long Spin(ISlot slot, int betAmount, ISlotRepository slotRepository);
    }
}
