using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Services
{
    internal class SlotService : ISlotService
    {
        public SlotResult Spin(ISlot slot, int betAmount, ISlotRepository repository)
        {
            var slotResult = slot.Spin(betAmount, 20);

            repository.RecordSlotResult(slotResult);

            return slotResult;
        }
    }
}
