using Assets.Scripts.Models.Units;

public class Unit : AbstractUnit
{
    public Unit(IUnitStats unitStats) {
        Stats = new BaseUnitStats(unitStats);
    }
}