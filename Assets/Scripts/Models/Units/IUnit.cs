using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IUnit : IModel
{
    public IUnitStats Stats { get; set; }
    public ICell CellParent { get; set; }
    public event EventHandler OnTurnCompleted;
    public event EventHandler<IUnit> OnDead;
    public void UseActiveAbility(IActiveAbility ability, ICell cell);
    public bool TryMove(ICell cell, IField field);
    public void SkipTurn();
    public void ApplyDamage(decimal damageAmount);
    public void ApplyHealth(decimal healthAmount);
    public void Die();
    public void ApplyPassiveAbilities();

}