using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class HostGamePresenter
    {
        private IHostGameUIView _view; 

        private List<IDataPlayer> _dataPlayers = new List<IDataPlayer>();

        private string _errorText;
        public EventHandler<string> OnErrorTextChanged;

        public HostGamePresenter(IHostGameUIView hostGameUIView)
        {
            _view = hostGameUIView;
        }

        public void OnPlayButtonClicked()
        {
            _dataPlayers.Clear();

            if (IsCorrectData() == false) return;



            for (int i = 0; i < _view.PlayersNamesField.Count; i++)
            {
                _dataPlayers.Add(new DataPlayer(_view.PlayersNamesField[i].text,
                   (TypeFaction)_view.PlayersFactionDropdown[i].value, int.Parse(_view.PlayersScoreField[i].text)));
            }


            ShowPlayerData(0);
            ShowPlayerData(1);
        }

        private bool IsCorrectData()
        {
            _errorText = string.Empty;

            for (int i = 0; i < _view.PlayersNamesField.Count; i++)
            {
                int playerNumber = i + 1;

                if (string.IsNullOrEmpty(_view.PlayersNamesField[i].text))
                {
                    _errorText = $"Имя игрока №{playerNumber} - пустое";
                    OnErrorTextChanged?.Invoke(this, _errorText);
                    return false;
                }

                if (string.IsNullOrEmpty(_view.PlayersScoreField[i].text) || _view.PlayersScoreField[i].text[0] == '0')
                {
                    _errorText = $"Количество очков игрока №{playerNumber} - пустое";
                    OnErrorTextChanged?.Invoke(this, _errorText);
                    return false;
                }

                if (_view.PlayersScoreField[i].text[0] == '-')
                {
                    _errorText = $"Количество очков игрока №{playerNumber} - отрицательное";
                    OnErrorTextChanged?.Invoke(this, _errorText);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(_view.SizeField.text))
            {
                _errorText = $"Размер поля не задан";
                OnErrorTextChanged?.Invoke(this, _errorText);
                return false;
            }

            if (_view.SizeField.text[0] == '-')
            {
                _errorText = $"Отрицательный размер поля";
                OnErrorTextChanged?.Invoke(this, _errorText);
                return false;
            }

            _errorText = string.Empty;
            OnErrorTextChanged?.Invoke(this, _errorText);

            return true;
        }

        private void ShowPlayerData(int i)
        {
            Debug.Log(_dataPlayers[i].Name);
            Debug.Log(_dataPlayers[i].Score);
            Debug.Log(_dataPlayers[i].Faction);
        }
    }
}
