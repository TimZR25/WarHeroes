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
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
        }

        public void Init(List<IDataPlayer> dataPlayers, int sizeField)
        {
            _presenter = new PreparationPresenter(dataPlayers, sizeField, _unitsConfig);

            InitUnits(dataPlayers);
        }

        private void InitUnits(List<IDataPlayer> dataPlayers)
        {
            for (int i = 0; i < dataPlayers.Count; i++)
            {
                _unitsPreparationViews[i].PlayerName.text = dataPlayers[i].Name;
                for (int j = 0; j < _unitsPreparationViews[i].UnitPreparationViews.Count; j++)
                {
                    UnitPreparationView unitPreparationView = _unitsPreparationViews[i].UnitPreparationViews[j];
                    UnitConfig[] unitConfigs = _unitsConfig.GetConfigByFaction(dataPlayers[i].Faction);

                    unitPreparationView.UnitAmount.text = "x0";
                    unitPreparationView.Image.sprite = unitConfigs[j].Sprite;
                    unitPreparationView.Image.SetNativeSize();
                }
            }
        }

        public void OnPlayButtonClicked()
        {

        }
    }
}