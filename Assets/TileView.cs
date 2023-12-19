using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour
{
    private int _x;
    private int _y;

    private bool _isDead;

    public Action<int, int> OnClicked;

    private void OnMouseDown()
    {
        OnClicked?.Invoke(_x, _y);
    }

    private void OnMouseEnter()
    {
        if (_isDead) return;

        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseExit()
    {
        if (_isDead) return;

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Init(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void ShowDead()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        _isDead = true;
    }
}
