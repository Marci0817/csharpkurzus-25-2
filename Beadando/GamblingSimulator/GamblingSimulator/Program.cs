using GamblingSimulator.Core;
using GamblingSimulator.Core.Slots;
using GamblingSimulator.Core.View;

ISlot slot = new BookOfFraSlot();

ISlotRenderer renderer = new SlotRenderer();


renderer.Render(slot.Spin(10, 20));