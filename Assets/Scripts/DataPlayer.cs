public class DataPlayer : IDataPlayer
{
    public string Name { get; set; }
    public TypeFaction Faction { get; set; }
    public int Score { get; set; }

    public DataPlayer(string name, TypeFaction faction, int score)
    {
        Name = name;
        Faction = faction;
        Score = score;
    }
}