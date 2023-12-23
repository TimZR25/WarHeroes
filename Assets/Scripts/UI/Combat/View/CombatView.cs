using Assets.Scripts.UI.Combat;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CombatView : MonoBehaviour, ICombatView
{
    [SerializeField] private GameConfig _gameConfig;

    [SerializeField] private CellView _cellView;

    [SerializeField] private Button _abilityButton;
    public Button AbilityButton => _abilityButton;

    [SerializeField] private Button _moveButton;
    public Button MoveButton => _moveButton;

    [SerializeField] private Button _skipButton;
    public Button SkipButton => _skipButton;

    [SerializeField] private Button _pauseButton;
    public Button PauseButton => _pauseButton;

    private CellView[,] _cellViews;
    public CellView[,] CellsViews => _cellViews;

    private CombatPresenter _presenter;

    public void Init(List<IPlayer> players)
    {
        CreateFieldView(_gameConfig.FieldWidth, _gameConfig.FieldHeight);

        _presenter = new CombatPresenter(this, _gameConfig, players);
    }

    private void CreateFieldView(int width, int height)
    {
        _cellViews = new CellView[width, height];

        Transform folder = new GameObject("CellViews").transform;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 position = new Vector3(i * _gameConfig.CellOffset.x, -j * _gameConfig.CellOffset.y, 0) + _gameConfig.FieldPosition;
                GameObject clone = Instantiate(_cellView.gameObject, position, Quaternion.identity, folder);

                if (clone.TryGetComponent(out CellView tileView))
                {
                    _cellViews[i, j] = tileView;
                    tileView.Init(i, j);

                    if (i >= width / 2) tileView.Flip(true);
                }
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
