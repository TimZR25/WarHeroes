using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Cell : ICell
{
    private IObstacle _obstacle;
    private IUnit _unit;

    public event EventHandler<int> OnModelChanged;

    public IObstacle Obstacle
    {
        get { return _obstacle; }
        set
        {
            _obstacle = value;
            OnModelChanged(this, _obstacle.ID);
        }
    }

    public List<ICell> Neighbors { get; set; }       
    public IUnit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            

            if (_unit == null)
            {
                OnModelChanged?.Invoke(this, 999);
                return;
            }

            _unit.CellParent = this;
            OnModelChanged?.Invoke(this, _unit.Stats.ID);
        }
    }

    public Cell()
    {
        Neighbors = new List<ICell>();
    }
}
