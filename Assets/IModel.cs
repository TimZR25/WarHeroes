using System;

public interface IModel
{
    public EventHandler<IUnit> OnDead { get; set; }

    public ICell CellParent { get; set; }
    public string GetSign();

    public void ApplyDamage(decimal damageAmount);
    public void ApplyHealth(decimal healthAmount);

    public void Die();
}
