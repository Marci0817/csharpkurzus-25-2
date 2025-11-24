using GamblingSimulator.Core;
using GamblingSimulator.Core.Slots;
using GamblingSimulator.Core.View;

ISlot slot = new BookOfFraSlot();

ISlotRenderer renderer = new SlotRenderer();

var oriasi = slot.Spin(10, 20);

Console.WriteLine(string.Join(',', oriasi.Row));
Console.WriteLine(oriasi.Payout);

//renderer.Render(slot.Spin(10, 20));