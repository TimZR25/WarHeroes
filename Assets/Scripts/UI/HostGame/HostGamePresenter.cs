using System;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public class HostGamePresenter
    {
        private IHostGameView _view;

        private string _errorText;

        public event EventHandler<string> OnErrorTextChanged;
        public Action<List<IDataPlayer>, int> OnDataApproved;

        public HostGamePresenter(IHostGameView hostGameUIView)
        {
            _view = hostGameUIView;
        }

        public void OnPlayButtonClicked()
        {
            List<IDataPlayer> dataPlayers = new List<IDataPlayer>();

            if (IsCorrectData() == false) return;



            for (int i = 0; i < _view.PlayersNamesField.Count; i++)
            {
                dataPlayers.Add(new DataPlayer(_view.PlayersNamesField[i].text,
                   (TypeFaction)_view.PlayersFactionDropdown[i].value));
            }

            int fieldSize = int.Parse(_view.SizeField.text);

            OnDataApproved?.Invoke(dataPlayers, fieldSize);
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
            }

            if (string.IsNullOrEmpty(_view.SizeField.text) || int.Parse(_view.SizeField.text) == 0)
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
    }
}
