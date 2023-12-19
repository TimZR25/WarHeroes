using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WeaponStrike : IActiveAbility
{
    public string Description
    {
        get; set;
    }
    public int Сost
    {
        get; set;
    }
    public decimal Multiplier => 3; public WeaponStrike(int сost)
    {
        Description = "Обычный удар оружием";
        Сost = сost;
    }
    public decimal Execute(decimal power)
    {
        return -power * Multiplier;
    }
}
