using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Regeneration : IPassiveAbility
{
    private IUnit _unit;
    private string _description;
    public decimal Coefficient => (decimal)1.2;
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


    public Regeneration(IUnit unit, string description)
    {
        Unit = unit;
        Description = description;
    }

    public void Execute()
    {
        if (Unit.Stats.Power * Coefficient + Unit.Stats.CurrentHealth >= Unit.Stats.MaxHealth) { Unit.Stats.CurrentHealth = Unit.Stats.MaxHealth; }
        else { Unit.Stats.CurrentHealth = Unit.Stats.Power * Coefficient + Unit.Stats.CurrentHealth; }
    }
}
