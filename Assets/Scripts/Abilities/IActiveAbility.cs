﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IActiveAbility: IAbility
{
    public int Сost { get; set; }

    public decimal Execute(decimal power);
}
