using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Storage;

namespace GamblingSimulator.Core.Services
{
    internal class SlotService : ISlotService
    {
        public long Spin(ISlot slot, int betAmount, ISlotRepository repository)
        {
            var slotResult = slot.Spin(betAmount, 20);

            repository.RecordSlotResult(slotResult);

            return slotResult.Payout;
        }
    }
}
