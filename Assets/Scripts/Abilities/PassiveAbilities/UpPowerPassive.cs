using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpPowerPassive : IPassiveAbility
{
    public string Description { get; set; }

    public decimal Multiplier => (decimal)1.1;

    public IUnit Unit { get; set; }

    public UpPowerPassive(IUnit unit)
    {
        Unit = unit;
        Description = "Повышает мощность каждый ход";
    }

    public void Execute()
    {
        Unit.Stats.Power = Unit.Stats.Power * Multiplier;
    }
}
