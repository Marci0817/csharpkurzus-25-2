using GamblingSimulator.Core;
using GamblingSimulator.Core.Contracts;
using GamblingSimulator.Core.Models;
using GamblingSimulator.Core.Services;
using GamblingSimulator.Core.View;
using GamblingSimulator.Models;

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
            _playerState = new PlayerState();

            AvailableSlots = SlotFactory.RetriveAllSlot();
            _renderer = new SlotRenderer();
            _slotService = SlotFactory.CreateSlotService();

            _slotInteractions = new Dictionary<int, Interaction>
            {
                { 1, new Interaction("Spin", SpinSlot) },
                { 2, new Interaction("Increase Bet", IncreaseBet) },
                { 3, new Interaction("Decrease Bet", DecreaseBet) },
            };
        }

        private int _slotChoice;
        private Dictionary<int, Interaction> _slotInteractions;
        private int _betAmount = 200;

        public void Start()
        {
            bool isRunning = true;
            Console.WriteLine($"Elérhető slotok:");
            for (int i = 0; i < AvailableSlots.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {AvailableSlots[i].Name}");
            }
            Console.WriteLine("Kérem válasszon egy slotot a fenti listából (szám alapján):");

            var slotInput = Console.ReadLine();

            while (!int.TryParse(slotInput, out _slotChoice))
            {
                Console.WriteLine("Érvénytelen slot, egy számot írjon be:");
                slotInput = Console.ReadLine();
            }
            Console.Clear();
            while (isRunning)
            {
                ShowPlayerState();
                foreach (var interaction in _slotInteractions)
                {
                    Console.WriteLine($"{interaction.Key}. {interaction.Value.Name}");
                }
                var input = Console.ReadLine();

                int interactionChoice;
                while (!int.TryParse(input, out interactionChoice))
                {
                    Console.WriteLine("Érvénytelen interakció, egy számot írjon be:");
                    input = Console.ReadLine();
                }
                Console.Clear();

                _slotInteractions.TryGetValue(
                    interactionChoice,
                    out Interaction? selectedInteraction
                );
                selectedInteraction?.Method();
            }
            Console.WriteLine("Viszlát! Vissza várjuk!");
        }

        private void SpinSlot()
        {
            long payout = _slotService.Spin(
                AvailableSlots[_slotChoice - 1],
                _betAmount,
                _playerState
            );
        }

        private void IncreaseBet()
        {
            _betAmount += 100;
        }

        private void DecreaseBet()
        {
            if (_betAmount - 100 >= 0)
            {
                _betAmount -= 100;
            }
        }

        private void ShowPlayerState()
        {
            Console.WriteLine(
                $"----- Üdv {_playerState.Name} ------ | Egyenleg: {_playerState.Balance} HUF | {DateTime.UtcNow}"
            );
            Console.WriteLine($"Jelenlegi tét: {_betAmount} HUF");
        }
    }
}
