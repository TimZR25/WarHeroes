using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IAbility
{
    public decimal Coefficient { get; set; }
    public string Description { get; set; }
    public bool IsHeal { get; set; }
}

