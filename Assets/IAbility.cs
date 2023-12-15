public interface IAbility
{
    string Description { get; set; }
    decimal Execute(decimal power);
}
