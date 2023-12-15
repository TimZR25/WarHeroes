using System.Collections.Generic;

public interface IField
{
    void AddModel(IModel model, int x, int y);
    public void ClearField();

    public List<ICell> GetNeighborsRadius(ICell cell, int radius);
}
