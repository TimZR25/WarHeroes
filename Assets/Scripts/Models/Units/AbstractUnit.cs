using System;

public abstract class AbstractUnit : IUnit
{

    public IUnitStats Stats { get; set; }

    public ICell CellParent { get; set; }

    public event EventHandler<IUnit> OnDead;


    public event EventHandler OnTurnCompleted;

    private bool isMoved = false;

    public AbstractUnit(IUnitStats unitStats)
    {
        Stats = unitStats;
    }

    public void UseActiveAbility(IActiveAbility ability, ICell cell)
    {
        if (Stats.CurrentEnergy < ability.Сost) return;

        isMoved = false;

        decimal amount = ability.Execute(Stats.Power);

        if (amount < 0) cell.Unit.ApplyDamage(amount);
        if (amount > 0) ApplyHealth(amount);

        OnTurnCompleted?.Invoke(this, EventArgs.Empty);
    }

    public bool TryMove(ICell cell, IField field)
    {
        if (isMoved == true) throw new Exception("Юнит уже походил");
        if (cell?.Unit != null) return false;
            
        if (field.GetNeighborsRadius(CellParent, Stats.DistanceOfMove).Contains(cell))
        {
            CellParent.Unit = null;
            cell.Unit = this;

            isMoved = true;
            return true;
        }

        return false;
    }

    public void ApplyDamage(decimal damageAmount)
    {
        decimal multiplier = (1 - Stats.Armor);
        if (Stats.CurrentHealth - (multiplier * damageAmount) <= 0)
        {
            Die();
            return;
        }

        Stats.CurrentHealth -= damageAmount * multiplier;
    }

    public void ApplyHealth(decimal healthAmount)
    {
        if (Stats.MaxHealth > Stats.CurrentHealth + healthAmount)
        {
            Stats.CurrentHealth = Stats.MaxHealth;
            return;
        }

        Stats.CurrentHealth += healthAmount;
    }

    public void Die()
    {
        CellParent.Unit = null;

        OnDead?.Invoke(this, this);
    }

    public void SkipTurn() {

        if (isMoved == false)
        {
            if (Stats.MaxEnergy >= Stats.CurrentEnergy + Stats.MaxEnergy * (decimal)0.2) { Stats.CurrentEnergy = Stats.MaxEnergy; }
            else { Stats.CurrentEnergy += Stats.MaxEnergy * (decimal)0.2; }
        }
        else
        {
            isMoved = false;
        }

        OnTurnCompleted?.Invoke(this, EventArgs.Empty);
    }

    public void ApplyPassiveAbilities() {
        if (Stats.PassiveAbilities.Count <= 1 || Stats.PassiveAbilities == null) { return; }

        foreach (IPassiveAbility passiveAbility in Stats.PassiveAbilities) {
            passiveAbility.Execute();
        }
    }
}

