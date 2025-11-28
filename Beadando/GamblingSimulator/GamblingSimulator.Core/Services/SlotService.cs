using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Services
{
    internal class SlotService : ISlotService
    {
        public long Spin(ISlot slot, int betAmount, PlayerState playerState)
        {
            var slotResult = slot.Spin(betAmount, 20);

            playerState.Balance += slotResult.Payout - betAmount;

            return slotResult.Payout;
        }
    }
}
