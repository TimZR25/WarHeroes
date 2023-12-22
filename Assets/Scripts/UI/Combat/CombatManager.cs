using System;
using System.Collections.Generic;
using System.Linq;

public class CombatManager : ICombatManager
{
    private IField _gameField;
    private List<IPlayer> _players;
    private IRoundManager _roundManager;
    public IUnit CurrentUnit { get; set; }
    public List<IUnit> UnitsCanTakeAction { get; set; }
    public PriorityQueue<IUnit, int> UnitsPriorityQueue { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    public event EventHandler<IPlayer> OnPlayerLose;
    public IField GameField
    {
        get { return _gameField; }
        set { _gameField = value; }
    }
    public List<IPlayer> Players
    {
        get { return _players; }
        set { _players = value; }
    }
    public IRoundManager RoundManager 
    {
        get { return _roundManager; }
        set { _roundManager = value; } 
    }
    public CombatManager(IField gameField, List<IPlayer> players, IRoundManager roundManager)
    {
        GameField = gameField;
        Players = players;
        RoundManager = roundManager;
        SubscribeUnitEvent();
    }
    public void ChangeCurrentPlayer()
    {
        foreach (IPlayer player in _players)
        {
            if (player.ControlledUnits.Contains(CurrentUnit)) CurrentPlayer = player;
        }
    }
    public void ChangeUnitsCanTakeAction()
    {
        foreach (IUnit unit in GetAllUnits())
        {
            UnitsCanTakeAction.Add(unit);
        }
    }

    public void RebuildQueue()
    {
        UnitsPriorityQueue.Clear();

        foreach (IUnit unit in UnitsCanTakeAction)
        {
            UnitsPriorityQueue.Enqueue(unit, -unit.Stats.Initiative);
        }
    }

    public void SubscribeUnitEvent() {
        foreach (IUnit unit in GetAllUnits()) {
            unit.OnTurnCompleted += NextTurn;
            unit.OnDead += RemoveDeadUnitFromField;
        }
    }


    public void NextTurn(object sender, IUnit args) // запускает сразу(0 раунда)
    {
        if (UnitsPriorityQueue.Count == 0)
        {
            if (RoundManager.Round != 0) 
            {
                ApplyAllPassiveAbilities(); 
            }

            RoundManager.NextRound();

            ChangeUnitsCanTakeAction();

            RebuildQueue();
        }


        UnitsCanTakeAction.Remove(CurrentUnit);
        CurrentUnit = UnitsPriorityQueue.Dequeue();
        ChangeCurrentPlayer();
    }

    public void RemoveDeadUnitFromField(object sender, IUnit unit) {
        foreach (IPlayer player in Players)
        {
            if (player.ControlledUnits.Contains(unit))
            {
                player.ControlledUnits.Remove(unit);
                if (player.ControlledUnits.Count == 0)
                {
                    OnPlayerLose.Invoke(this, player);
                    return;
                }
                else {
                    unit.OnDead -= RemoveDeadUnitFromField;
                    unit.OnTurnCompleted -= NextTurn;

                    if (UnitsCanTakeAction.Contains(unit)) 
                    {
                        UnitsCanTakeAction.Remove(unit); 
                    }

                    RebuildQueue();
                    return;
                }
            }
        }
    }

    public void ApplyAllPassiveAbilities() {
        foreach (IUnit unit in GetAllUnits()) {
            unit.ApplyPassiveAbilities();
        }
    }

    public List<IUnit> GetAllUnits()
    {
        List<IUnit> result = new List<IUnit>();

        foreach (IPlayer player in Players)
        {
            foreach (IUnit unit in player.ControlledUnits)
            {
                result.Add(unit);
            }
        }

        return result;
    }
}

