using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpArmor : IPassiveAbility
{
    private IUnit _unit;
    private string _description;
    public decimal Coefficient => 1;
    public IUnit Unit
    {
        get { return _unit; }
        set { if (_unit == null) throw new ArgumentNullException("Unit не может быть null"); _unit = value; }
    }

    public string Description
    {
        get { return _description; }
        set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Description не может быть null или empty"); _description = value; }
    }

    public UpArmor(IUnit unit, string description)
    {
        Unit = unit;
        Description = description;
    }

    public void Execute()
    {
        if (Unit.Stats.Armor + Coefficient >= Unit.Stats.MaxArmor) { Unit.Stats.Armor = Unit.Stats.MaxArmor; }
        else { Unit.Stats.Armor = Unit.Stats.Armor + (int)Coefficient; }
    }
}
