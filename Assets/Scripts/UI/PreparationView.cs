using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
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
            _presenter.Init(dataPlayers, sizeField, _unitsConfig);

            InitUnits(dataPlayers);
        }

        private void InitUnits(List<IDataPlayer> dataPlayers)
        {
            for (int i = 0; i < dataPlayers.Count; i++)
            {
                _unitsPreparationViews[i].PlayerName.text = dataPlayers[i].Name;
                for (int j = 0; j < _unitsPreparationViews[i].UnitPreparationViews.Count; j++)
                {
                    IUnitPreparationView unitPreparationView = _unitsPreparationViews[i].UnitPreparationViews[j];
                    UnitConfig[] unitConfigs = _unitsConfig.GetConfigByFaction(dataPlayers[i].Faction);

                    unitPreparationView.UnitAmount.text = "x0";
                    unitPreparationView.Image.sprite = unitConfigs[j].Sprite;
                    unitPreparationView.Image.SetNativeSize();
                }
            }
        }

        public void PlayButtonClicked()
        {

        }

        public void PlusButtonClicked(object sender, IUnitPreparationView unitPreparationView)
        {
            _presenter.AddUnit(unitPreparationView);
        }

        public void MinusButtonClicked(object sender, IUnitPreparationView unitPreparationView)
        {
            _presenter.RemoveUnit(unitPreparationView);
        }
    }
}