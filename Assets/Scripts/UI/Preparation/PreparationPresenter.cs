using System;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public class PreparationPresenter
    {
        private IPreparationView _view;

        public List<PlayerUnitsCollection> PlayersUnits { set; get; }

        private List<IDataPlayer> _dataPlayers;
        private int _sizeField;

        private UnitsConfig _unitsConfig;

        public event EventHandler<int> Player1_OnWarriorAmountChanged;
        public event EventHandler<int> Player1_OnArcherAmountChanged;
        public event EventHandler<int> Player1_OnMageAmountChanged;

        public event EventHandler<int> Player2_OnWarriorAmountChanged;
        public event EventHandler<int> Player2_OnArcherAmountChanged;
        public event EventHandler<int> Player2_OnMageAmountChanged;

        public event EventHandler<int> Player1_OnUnitAmountChanged;
        public event EventHandler<int> Player2_OnUnitAmountChanged;

        public PreparationPresenter(IPreparationView view)
        {
            _view = view;
        }

        public void Init(List<IDataPlayer> dataPlayers, int sizeField, UnitsConfig unitsConfig)
        {
            _dataPlayers = dataPlayers;
            _sizeField = sizeField;
            _unitsConfig = unitsConfig;

            PlayersUnits = new List<PlayerUnitsCollection>
            {
                new PlayerUnitsCollection(_unitsConfig, _dataPlayers[0].Faction),
                new PlayerUnitsCollection(_unitsConfig, _dataPlayers[1].Faction)
            };

            PlayersUnits[0].OnWarriorAmountChanged += Player1_WarriorAmountChanged;
            PlayersUnits[0].OnArcherAmountChanged += Player1_ArcherAmountChanged;
            PlayersUnits[0].OnMageAmountChanged += Player1_MageAmountChanged;

            PlayersUnits[1].OnWarriorAmountChanged += Player2_WarriorAmountChanged;
            PlayersUnits[1].OnArcherAmountChanged += Player2_ArcherAmountChanged;
            PlayersUnits[1].OnMageAmountChanged += Player2_MageAmountChanged;
        }

        public void AddUnit(IUnitPreparationView unitPreparationView)
        {
            if (PlayersUnits[(int)unitPreparationView.PlayerNumber].AllUnits.Count >= _sizeField)
                return;

            PlayersUnits[(int)unitPreparationView.PlayerNumber].AddUnit(unitPreparationView.TypeRole);
        }

        public void RemoveUnit(IUnitPreparationView unitPreparationView)
        {
            PlayersUnits[(int)unitPreparationView.PlayerNumber].RemoveUnit(unitPreparationView.TypeRole);
        }

        public void Player1_WarriorAmountChanged(object sender, int unitAmount)
        {
            Player1_OnWarriorAmountChanged?.Invoke(sender, unitAmount);
            Player1_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[0].AllUnits.Count);
        }

        public void Player1_ArcherAmountChanged(object sender, int unitAmount)
        {
            Player1_OnArcherAmountChanged?.Invoke(sender, unitAmount);
            Player1_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[0].AllUnits.Count);
        }

        public void Player1_MageAmountChanged(object sender, int unitAmount)
        {
            Player1_OnMageAmountChanged?.Invoke(sender, unitAmount);
            Player1_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[0].AllUnits.Count);
        }

        public void Player2_WarriorAmountChanged(object sender, int unitAmount)
        {
            Player2_OnWarriorAmountChanged?.Invoke(sender, unitAmount);
            Player2_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[1].AllUnits.Count);
        }

        public void Player2_ArcherAmountChanged(object sender, int unitAmount)
        {
            Player2_OnArcherAmountChanged?.Invoke(sender, unitAmount);
            Player2_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[1].AllUnits.Count);
        }

        public void Player2_MageAmountChanged(object sender, int unitAmount)
        {
            Player2_OnMageAmountChanged?.Invoke(sender, unitAmount);
            Player2_OnUnitAmountChanged?.Invoke(sender, _sizeField - PlayersUnits[1].AllUnits.Count);
        }
    }
}
