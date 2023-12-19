using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Tile
{
    public string Name { get; private set; }

    public int X { get; private set; }
    public int Y { get; private set; }

    private int _health;

    public int Health
    {
        get { return _health; }
        set
        {
                OnDead?.Invoke(this, this);
            return;
            if (value <= 0)
            {
                _health = 0;
                return;
            }

            _health = value;
        }
    }

    public event EventHandler<Tile> OnDead;

    public Tile(string name, int health, int x, int y)
    {
        Name = name;
        Health = health;
        X = x;
        Y = y;
    }
}
