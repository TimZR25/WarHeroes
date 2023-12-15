public interface IUnitStats
{
    public string Name { get; }

    public decimal MaxHealth {  get; }

    public decimal CurrentHealth { get; set; }

    public decimal Power { get; set; }

    public int Armor { get; set; }

    public string Description { get;  set; }

    public int DistanceOfMove { get; set; }

    public int Initiative { get; set; }

    public int Score { get; }

    public int AmountEnergy { get; set; }
}