using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChargedWeaponStrike
{
    public decimal Multiplier => 3;

    public string Description { get; set; }

    public int Сost { get; set; }

    public ChargedWeaponStrike(int сost) // подумать
    {
        Description = "Заряженный удар оружием";
        Сost = сost;
    }

    public decimal Execute(decimal power)
    {
        return -power * Multiplier;
    }
}
