public class Unit : AbstractUnit
{
    public Unit(IUnitStats unitStats) {
        Stats = unitStats;
        Stats.CurrentHealth = Stats.MaxHealth;
        Stats.CurrentEnergy = Stats.MaxEnergy;
    }
}