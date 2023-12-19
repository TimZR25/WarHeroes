using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HostGameView : MonoBehaviour, IHostGameView
    {
        [SerializeField] private PreparationView _preparationView;

        [SerializeField] private Button _playButton;

        [SerializeField] private TMP_InputField _sizeField;
        public TMP_InputField SizeField => _sizeField;

        [SerializeField] private TextMeshProUGUI _errorText;
        public TextMeshProUGUI ErrorText => _errorText;

        [SerializeField] private List<TMP_InputField> _playersNameField;
        public List<TMP_InputField> PlayersNamesField => _playersNameField;

        [SerializeField] private List<TMP_Dropdown> _playersFactionDropdown;
        public List<TMP_Dropdown> PlayersFactionDropdown => _playersFactionDropdown;


        private HostGamePresenter _presenter;


        public void Init(HostGamePresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _presenter.OnErrorTextChanged += DisplayError;
            _presenter.OnDataApproved += ShowPreparationView;
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _presenter.OnErrorTextChanged -= DisplayError;
            _presenter.OnDataApproved -= ShowPreparationView;
        }

        public void OnPlayButtonClicked()
        {
            _presenter.OnPlayButtonClicked();
        }

        public void DisplayError(object sender, string text)
        {
            _errorText.text = text;
        }

        public void ShowPreparationView(List<IDataPlayer> dataPlayers, int sizeField)
        {
            _preparationView.gameObject.SetActive(true);
            _preparationView.Init(dataPlayers, sizeField);
            gameObject.SetActive(false);
        }
    }
}
