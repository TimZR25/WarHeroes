using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FireBall : IActiveAbility
{
    private int _cost;
    private string _description;
    public string Description
    {
        get { return _description; }
        set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Description не может быть null или empty"); _description = value; }
    }
    public int Cost
    {
        get { return _cost; }
        set { if (value < 0) throw new ArgumentOutOfRangeException("Cost не может быть отрицательным"); _cost = value; }
    }

    public decimal Coefficient => 5;

    public FireBall(int cost, string description)
    {
        Description = description;
        Cost = cost;
    }

    public decimal Execute(decimal power)
    {
        return -power * Coefficient;
    }
}

