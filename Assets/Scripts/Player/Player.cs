using System;
using System.Collections.Generic;

public class Player : IPlayer
{
    private string _name;

    private List<IUnit> _controlledUnits;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<IUnit> ControlledUnits
    {
        get { return _controlledUnits; }
        set { _controlledUnits = value; }
    }

    public Player(string name, List<IUnit> units)
    {
        Name = name;
        ControlledUnits = units;

        foreach (IUnit unit in units)
        {
            unit.OnDead += RemoveUnit;
        }
    }

    public void AddUnit(IUnit unit)
    {
        if (unit == null) throw new NullReferenceException("Игрок получил пустую ссылку на юнита");

        unit.OnDead += RemoveUnit;

        ControlledUnits.Add(unit);
    }

    public void RemoveUnit(object sender, IUnit unit)
    {
        unit.OnDead -= RemoveUnit;

        ControlledUnits.Remove(unit);
    }
}
