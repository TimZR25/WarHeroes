using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
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
}
