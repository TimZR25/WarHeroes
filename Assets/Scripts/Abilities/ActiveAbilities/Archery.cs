using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Archery : IActiveAbility
{
    public decimal Multiplier => 2; 

    public string Description { get; set; }

    public int Сost { get; set; }

    public Archery(int сost)
    {
        Description = "Обычный выстрел из лука";
        Сost = сost;
    }
    public decimal Execute(decimal power)
    {
        return -power * Multiplier;
    }
}
