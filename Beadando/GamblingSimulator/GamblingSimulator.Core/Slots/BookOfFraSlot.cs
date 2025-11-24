using GamblingSimulator.Core.Models;
using GamblingSimulator.Core.Models.SlotModels;

namespace GamblingSimulator.Core.Slots;

public class BookOfFraSlot : ISlot
{
    public List<string> Symbols = new List<string>() { "😁", "♔", "🆘", "A", "B" };
    public IEnumerable<SlotState> Spin(long bet, int length)
    {
        for( int i = 0; i < length; i++ )
        {
            yield return new SlotState([firstSymbol, secondSymbol, threeSymbol]);
        }
    }

    private double GenerateRandomDouble(double min, double max)
    {
        Random random = new Random();
        return random.NextDouble() * (max - min) + min;
    }

    private int RandomSymbol()
    {
        Random random = new Random();

        return random.Next(1, (int)BookOfFraSymbol.Book);
    }
}