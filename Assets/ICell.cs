using System.Collections.Generic;

public interface ICell
{
    public IModel Model { get; set; }
    public List<ICell> Neighbors { get; set; }
    //public void ClearModelInCell();
}
