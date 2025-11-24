using GamblingSimulator.Core;
using GamblingSimulator.Core.Models;
using GamblingSimulator.Core.View;

namespace GamblingSimulator.UI
{
    internal class CasinoGame : ICasinoGame
    {
        private PlayerState _playerState { get; set; }

        public IList<ISlot> AvailableSlots { get; private set; }


        private ISlotRenderer _renderer { get; set; }
        public CasinoGame()
        {
            _playerState = new PlayerState(0);

            AvailableSlots = SlotFactory.RetriveAllSlot();
            _renderer = new SlotRenderer();
        }

        public void Start()
        {
            bool isRunning = true;

            while(isRunning)
            {
                ShowPlayerState();
                Console.WriteLine($"\n\n1. list all slots | 2. play slot | 3 break");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
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

            var oriasi = slot.Spin(300, 20);

            Console.WriteLine(string.Join(',', oriasi.Row));
            Console.WriteLine(oriasi.Payout);
            //_renderer.Render(slot.Spin(10, 20));
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
