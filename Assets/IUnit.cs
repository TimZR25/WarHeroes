public interface IUnit : IUnitStats, IModel
{
    public void UseAbility(IActiveAbility ability, ICell cell);
    public bool TryMove(ICell cell, IField field);
}