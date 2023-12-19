using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExplosiveArchery : IActiveAbility
{
    public string Description { get; set; }

    public int Сost { get; set; }

    public decimal Multiplier => 4; 
    
    public ExplosiveArchery(int сost)
    {
        Description = "Взрывной выстрел из лука";
        Сost = сost;
    }
    public decimal Execute(decimal power)
    {
        return -power * Multiplier;
    }
}
