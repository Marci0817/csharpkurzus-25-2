using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Services
{
    public interface ISlotService
    {
        long Spin(ISlot slot, int betAmount, ref PlayerState playerState);
    }
}