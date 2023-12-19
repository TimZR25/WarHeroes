using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IObstacle : IModel
{
    public string Description { get; set; }
}

