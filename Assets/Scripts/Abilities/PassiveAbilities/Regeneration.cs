using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Regeneration : IPassiveAbility
{
    public IUnit Unit { get; set; }

    public string Description { get; set; }

    public decimal Multiplier => (decimal)1.2;

    public Regeneration(IUnit unit)
    {
        Unit = unit;
        Description = "Регенерация здоровья каждый ход";
    }

    public void Execute()
    {
        if (Unit.Stats.Power * Multiplier + Unit.Stats.CurrentHealth >= Unit.Stats.MaxHealth) { Unit.Stats.CurrentHealth = Unit.Stats.MaxHealth; }
        else { Unit.Stats.CurrentHealth = Unit.Stats.Power * Multiplier + Unit.Stats.CurrentHealth; }
    }
}
