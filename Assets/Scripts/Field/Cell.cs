using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Cell : ICell
{
    private IUnit _unit;
    public IObstacle Obstacle { get; set; }
    public List<ICell> Neighbors { get; set; }       
    public IUnit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            _unit.CellParent = this;
        }
    }

    public Cell(int x, int y)
    {
        Neighbors = new List<ICell>();
    }
}
