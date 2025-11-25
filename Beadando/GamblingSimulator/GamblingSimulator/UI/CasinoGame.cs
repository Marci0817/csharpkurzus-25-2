using GamblingSimulator.Core;
using GamblingSimulator.Core.Models;
using GamblingSimulator.Core.Services;
using GamblingSimulator.Core.View;

namespace GamblingSimulator.UI
{
    internal class CasinoGame : ICasinoGame
    {
        private PlayerState _playerState;

        public IList<ISlot> AvailableSlots { get; private set; }


        private ISlotRenderer _renderer { get; set; }
        private ISlotService _slotService { get; set; }
        public CasinoGame()
        {
            _playerState = new PlayerState(0);

            AvailableSlots = SlotFactory.RetriveAllSlot();
            _renderer = new SlotRenderer();
            _slotService = SlotFactory.CreateSlotService();
        }

        public void Start()
        {
            bool isRunning = true;

            while(isRunning)
            {
                ShowPlayerState();
                Console.WriteLine($"\nHELP: Type 1 to list all slots | 2 to play slot | 3 to exit");
                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        ListAllSlots();
                        break;
                    case "2":
                        Console.Clear();
                        HandleSlotGame();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.WriteLine("Viszlát! Vissza várjuk!");
        }

        private void HandleSlotGame()
        {
            var slot = AvailableSlots[0];
            Console.WriteLine($"------- [ {slot.Name} ] -------");

            long payout = _slotService.Spin(slot, 200, ref _playerState);

            Console.WriteLine($"{payout}");
        }

        private void ListAllSlots()
        {
            for (int i = 0; i < AvailableSlots.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableSlots[i].Name}");
            }
        }

        private void ShowPlayerState()
        {
            Console.WriteLine($"----- Welcome {_playerState.Name} ------ | Balance: {_playerState.Balance} HUF | {DateTime.UtcNow}");
        }
    }
}
