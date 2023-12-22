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

    [field: SerializeField] public Button AbilityButton {  get; set; }
    [field: SerializeField] public Button MoveButton { get; set; }
    [field: SerializeField] public Button SkipButton { get; set; }
    [field: SerializeField] public Button PauseButton { get; set; }

    private CellView[,] _cellViews;

    private CombatPresenter _presenter;

    public void Init(List<IPlayer> players)
    {
        CreateFieldView(_gameConfig.FieldWidth, _gameConfig.FieldHeight);

        _presenter = new CombatPresenter(_gameConfig, players);

        SubscribeCells();
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
                }
            }
        }
    }

    private void SubscribeCells()
    {
        for (int x = 0; x < _cellViews.GetLength(0); x++)
        {
            for (int y = 0; y < _cellViews.GetLength(1); y++)
            {
                _cellViews[x, y].OnClicked += _presenter.TileClicked;
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
