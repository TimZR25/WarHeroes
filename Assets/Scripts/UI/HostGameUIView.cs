using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HostGameUIView : HostGameView , IHostGameUIView
    {
        [SerializeField] private Button _playButton;

        [SerializeField] private TMP_InputField _sizeField;
        public TMP_InputField SizeField
        {
            get { return _sizeField; }
            set { _sizeField = value; }
        }

        [SerializeField] private TextMeshProUGUI _errorText;
        public TextMeshProUGUI ErrorText
        {
            get { return _errorText; }
            set { _errorText = value; }
        }

        [SerializeField] private List<TMP_InputField> _playersNameField;
        public List<TMP_InputField> PlayersNamesField
        {
            get { return _playersNameField; }
            set { _playersNameField = value; }
        }

        [SerializeField] private List<TMP_InputField> _playersScoreField;
        public List<TMP_InputField> PlayersScoreField
        {
            get { return _playersScoreField; }
            set { _playersScoreField = value; }
        }

        [SerializeField] private List<TMP_Dropdown> _playersFactionDropdown;
        public List<TMP_Dropdown> PlayersFactionDropdown
        {
            get { return _playersFactionDropdown; }
            set { _playersFactionDropdown = value; }
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _presenter.OnErrorTextChanged += DisplayError;
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _presenter.OnErrorTextChanged -= DisplayError;
        }

        public void OnPlayButtonClicked()
        {
            _presenter.OnPlayButtonClicked();
        }

        public void DisplayError(object sender, string text)
        {
            _errorText.text = text;
        }
    }
}
