using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private TileView _tileViews;
    [SerializeField] private int _sizeSide;

    private TileView[,] _tilesViews;

    private Tile[,] _tiles;

    private void Start()
    {
        _tiles = new Tile[_sizeSide, _sizeSide];
        _tilesViews = new TileView[_sizeSide, _sizeSide];

        for (int i = 0; i < _sizeSide; i++)
        {
            for (int j = 0; j < _sizeSide; j++)
            {
                GameObject clone = Instantiate(_tileViews.gameObject, new Vector3(i, j), Quaternion.identity);

                if (clone.TryGetComponent(out TileView tileView))
                {
                    _tilesViews[i, j] = tileView;

                    _tiles[i, j] = new Tile($"Tile {i} : {j}", 10, i, j);

                    tileView.Init(i, j);
                    tileView.OnClicked += TileClicked;
                    _tiles[i, j].OnDead += ShowTile;
                }
            }
        }
    }

    public void TileClicked(int x, int y)
    {
        _tiles[x, y].Health -= 5;
    }

    public void ShowTile(object sender, Tile tile)
    {
        _tilesViews[tile.X, tile.Y].ShowDead();
        Debug.Log(tile.Name + " is dead");
    }
}
