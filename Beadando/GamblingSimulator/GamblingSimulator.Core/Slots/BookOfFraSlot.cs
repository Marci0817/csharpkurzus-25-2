using GamblingSimulator.Core.Models;

namespace GamblingSimulator.Core.Slots;

public class BookOfFraSlot : ISlot
{
    public IEnumerable<SlotState> Spin(long bet, int length)
    {
        for( int i = 0; i < length; i++ )
        {
            yield return new SlotState([1, 2, 3]);
        }
    }
}