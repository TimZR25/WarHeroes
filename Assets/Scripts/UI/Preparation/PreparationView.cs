using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PreparationView : MonoBehaviour, IPreparationView
    {
        [SerializeField] private UnitsConfig _unitsConfig;

        [SerializeField] private List<UnitsPreparationView> _unitsPreparationViews;
        public List<UnitsPreparationView> UnitsPreparationViews => _unitsPreparationViews;

        [SerializeField] private Button _playButton;

        private PreparationPresenter _presenter;

        private void OnEnable()
        {
            if (_presenter == null) _presenter = new PreparationPresenter(this);


            _playButton.onClick.AddListener(PlayButtonClicked);

            _presenter.Player1_OnUnitAmountChanged += Player1_UnitAmountChanged;
            _presenter.Player2_OnUnitAmountChanged += Player2_UnitAmountChanged;


            for (int i = 0; i < _unitsPreparationViews.Count; i++)
            {
                for (int j = 0; j < _unitsPreparationViews[i].UnitPreparationViews.Count; j++)
                {
                    IUnitPreparationView unitPreparationView = _unitsPreparationViews[i].UnitPreparationViews[j];

                    unitPreparationView.OnMinusButtonClicked += MinusButtonClicked;
                    unitPreparationView.OnPlusButtonClicked += PlusButtonClicked;

                    switch (unitPreparationView.PlayerNumber)
                    {
                        case PlayerNumber.Player1:
                            switch (unitPreparationView.TypeRole)
                            {
                                case TypeRole.WARRIOR:
                                    _presenter.Player1_OnWarriorAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                case TypeRole.ARCHER:
                                    _presenter.Player1_OnArcherAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                case TypeRole.MAGE:
                                    _presenter.Player1_OnMageAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case PlayerNumber.Player2:
                            switch (unitPreparationView.TypeRole)
                            {
                                case TypeRole.WARRIOR:
                                    _presenter.Player2_OnWarriorAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                case TypeRole.ARCHER:
                                    _presenter.Player2_OnArcherAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                case TypeRole.MAGE:
                                    _presenter.Player2_OnMageAmountChanged += unitPreparationView.ChangeUnitAmount;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();

            _presenter.Player1_OnUnitAmountChanged -= Player1_UnitAmountChanged;
            _presenter.Player2_OnUnitAmountChanged -= Player2_UnitAmountChanged;

            for (int i = 0; i < _unitsPreparationViews.Count; i++)
            {
                for (int j = 0; j < _unitsPreparationViews[i].UnitPreparationViews.Count; j++)
                {
                    IUnitPreparationView unitPreparationView = _unitsPreparationViews[i].UnitPreparationViews[j];

                    unitPreparationView.OnMinusButtonClicked -= MinusButtonClicked;
                    unitPreparationView.OnPlusButtonClicked -= PlusButtonClicked;

                    switch (unitPreparationView.TypeRole)
                    {
                        case TypeRole.WARRIOR:
                            _presenter.Player1_OnWarriorAmountChanged -= unitPreparationView.ChangeUnitAmount;
                            break;
                        case TypeRole.ARCHER:
                            _presenter.Player1_OnArcherAmountChanged -= unitPreparationView.ChangeUnitAmount;
                            break;
                        case TypeRole.MAGE:
                            _presenter.Player1_OnMageAmountChanged -= unitPreparationView.ChangeUnitAmount;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void Init(List<IDataPlayer> dataPlayers, int sizeField)
        {
            InitUnits(dataPlayers, sizeField);

            _presenter.Init(dataPlayers, sizeField, _unitsConfig);
        }

        private void InitUnits(List<IDataPlayer> dataPlayers, int sizeField)
        {
            for (int i = 0; i < dataPlayers.Count; i++)
            {
                _unitsPreparationViews[i].PlayerName.text = dataPlayers[i].Name;
                _unitsPreparationViews[i].UnitAmount.text = "Можно взять: " + sizeField.ToString();

                for (int j = 0; j < _unitsPreparationViews[i].UnitPreparationViews.Count; j++)
                {
                    IUnitPreparationView unitPreparationView = _unitsPreparationViews[i].UnitPreparationViews[j];
                    UnitConfig[] unitConfigs = _unitsConfig.GetByFaction(dataPlayers[i].Faction);

                    unitPreparationView.UnitAmount.text = "x0";
                    unitPreparationView.Image.sprite = unitConfigs[j].Sprite;
                    unitPreparationView.Image.SetNativeSize();
                }
            }
        }

        public void PlayButtonClicked()
        {
            foreach (PlayerUnitsCollection playerCollection in _presenter.PlayersUnits)
            {
                foreach (IUnit unit in playerCollection.AllUnits)
                {
                    Debug.Log(unit.Stats.Name);
                }
            }
        }

        public void PlusButtonClicked(object sender, IUnitPreparationView unitPreparationView)
        {
            _presenter.AddUnit(unitPreparationView);
        }

        public void MinusButtonClicked(object sender, IUnitPreparationView unitPreparationView)
        {
            _presenter.RemoveUnit(unitPreparationView);
        }

        public void Player1_UnitAmountChanged(object sender, int amount)
        {
            _unitsPreparationViews[0].UnitAmount.text = "Можно взять: " + amount.ToString();
        }

        public void Player2_UnitAmountChanged(object sender, int amount)
        {
            _unitsPreparationViews[1].UnitAmount.text = "Можно взять: " + amount.ToString();
        }
    }
}