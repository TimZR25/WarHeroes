using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private SpritesConfig _spritesConfig;
    [SerializeField] private SpriteRenderer _modelRenderer;

    private int _x;
    private int _y;

    public Action<int, int> OnClicked;

    private void OnMouseDown()
    {
        OnClicked?.Invoke(_x, _y);
    }

    public void Init(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void ChangeModel(object sender, int id)
    {
        if (id == 999)
        {
            _modelRenderer.sprite = null;
            return;
        }

        _modelRenderer.sprite = _spritesConfig.Configs[id].Sprite;
    }

    public void Flip(bool flipX)
    {
        _modelRenderer.flipX = flipX; 
    }
}
