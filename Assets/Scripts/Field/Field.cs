using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Field : IField
{
    private ICell[,] _field;

    private int _fieldWidth;
    private int _fieldHeight;

    public Field(int fieldWidth, int fieldHeight)
    {
        _fieldWidth = fieldWidth;
        _fieldHeight = fieldHeight;

        _field = new ICell[_fieldWidth, _fieldHeight];

        for (int x = 0; x < _fieldWidth; x++)
        {
            for (int y = 0; y < _fieldHeight; y++)
            {
                ICell cell = new Cell(x, y);
                _field[x, y] = cell;
            }
        }

        AddNeighborsAll();
    }

    public void AddUnit(IUnit unit, int x, int y)
    {
        if (_field[x, y].Unit == null && _field[x, y].Obstacle == null) _field[x, y].Unit = unit;
        else 
        {
            throw new ArgumentException("Клетка уже занята");
        }
    }
    public void AddObstacle(IObstacle obstacle, int x, int y)
    {
        if (_field[x, y].Unit == null && _field[x, y].Obstacle == null) _field[x, y].Obstacle = obstacle;
        else
        {
            throw new ArgumentException("Клетка уже занята");
        }
    }

    public ICell GetCell(int x, int y)
    {
        if (x > _fieldWidth || y > _fieldHeight || x < 0 || y < 0) {
            throw new ArgumentOutOfRangeException("Некорректные координаты для получения клетки");
        }

        return _field[x, y];
    }

    public void ClearField()
    {
        foreach (ICell cell in _field)
        {
            cell.Unit = null;
            cell.Obstacle = null;
        }
    }

    private void AddNeighborsAll()
    {
        for (int x = 0; x < _fieldWidth; x++)
        {
            for (int y = 0; y < _fieldHeight; y++)
            {
                AddNeighbors(x, y);
            }
        }
    }

    private IEnumerable<int> Shifts(int v, int? max)
    {
        yield return 0;
        if (v > 0) yield return -1;
        if (v < max - 1) yield return 1;
    }

    private void AddNeighbors(int x, int y)
    {
        foreach (int dx in Shifts(x, _fieldWidth))
        {
            foreach (int dy in Shifts(y, _fieldHeight))
            {
                if ((dx == 0) && (dy == 0))
                    continue;
                _field[x, y].Neighbors.Add(_field[x + dx, y + dy]);
            }
        }
    }

    public List<ICell> GetNeighborsRadius(ICell cell, int radius)
    {
        if (cell == null) throw new ArgumentNullException("Пустая ссылка на клетку");
        if (radius < 1) throw new ArgumentOutOfRangeException("Радиус не может быть меньше 1");

        HashSet<ICell> result = new HashSet<ICell>(cell.Neighbors)
        {
            cell
        };

        int count = 1;

        HashSet<ICell> neighbors = new HashSet<ICell>(cell.Neighbors);

        while (count != radius)
        {
            List<ICell> currentCells = new List<ICell>(neighbors);
            neighbors.Clear();

            for (int i = 0; i < currentCells.Count; i++)
            {
                for (int j = 0; j < currentCells[i].Neighbors.Count; j++)
                {
                    neighbors.Add(currentCells[i].Neighbors[j]);
                    result.Add(currentCells[i].Neighbors[j]);
                }
            }
            count++;
        }

        result.Remove(cell);

        return new List<ICell>(result);
    }
}
