﻿using System;

public interface IUnit
{
    public IUnitStats Stats { get; set; }

    public ICell CellParent { get; set; }

    public event EventHandler<IUnit> OnTurnCompleted;
    public event EventHandler<IUnit> OnDead;

    public bool TryUseActiveAbility(IActiveAbility ability, ICell cell);
    public bool TryMove(ICell cell, IField field);
    public void SkipTurn();

    public void ApplyDamage(decimal damageAmount);
    public void ApplyHealth(decimal healthAmount);
    public void Die();
    public void ApplyPassiveAbilities();

}
