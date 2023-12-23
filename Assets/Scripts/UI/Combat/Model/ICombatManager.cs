using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public interface ICombatManager
{
    public List<IUnit> UnitsCanTakeAction { get; set; }
    public IField GameField { get; set; }
    public List<IPlayer> Players { get; set; }
    public PriorityQueue<IUnit, int> UnitsPriorityQueue { get; set; }
    public IRoundManager RoundManager { get; set; }
    public IPlayer CurrentPlayer { get; set; }
    public IUnit CurrentUnit { get; set; }
    public void ChangeCurrentPlayer();
    public void ChangeUnitsCanTakeAction();
    public void RebuildQueue();
    public void StartGame();
    public event EventHandler OnCurrentUnitChanged;
}

