﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICell
{
    public IObstacle Obstacle { get; set; }
    public IUnit Unit { get; set; }
    public List<ICell> Neighbors { get; set; }
}
