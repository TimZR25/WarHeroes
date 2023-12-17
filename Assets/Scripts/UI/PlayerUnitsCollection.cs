using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PlayerUnitsCollection : IPlayerUnitsCollection
    {
        //

        public List<IUnit> AllUnits => Warriors.Concat(Archers).Concat(Mages).ToList();

        private List<IUnit> _warriors = new List<IUnit>();
        public List<IUnit> Warriors => _warriors;

        private List<IUnit> _archers = new List<IUnit>();
        public List<IUnit> Archers => _archers;

        private List<IUnit> _mages = new List<IUnit>();
        public List<IUnit> Mages => _mages;


        public event EventHandler<int> OnWarriorAmountChanged;
        public event EventHandler<int> OnArcherAmountChanged;
        public event EventHandler<int> OnMageAmountChanged;


        public PlayerUnitsCollection(/*Фабрика*/)
        {

        }

        public void AddUnit(TypeRole role)
        {
            switch (role)
            {
                case TypeRole.WARRIOR:
                    Warriors.Add(new BaseUnit());
                    OnWarriorAmountChanged?.Invoke(this, Warriors.Count);
                    break;
                case TypeRole.ARCHER:
                    Archers.Add(new BaseUnit());
                    OnArcherAmountChanged?.Invoke(this, Archers.Count);
                    break;
                case TypeRole.MAGE:
                    Mages.Add(new BaseUnit());
                    OnMageAmountChanged?.Invoke(this, Mages.Count);
                    break;
            }
        }

        public void RemoveUnit(TypeRole role)
        {
            switch (role)
            {
                case TypeRole.WARRIOR:
                    if (Warriors.Count < 1) return;
                    Warriors.RemoveAt(0);
                    OnWarriorAmountChanged?.Invoke(this, Warriors.Count);
                    break;
                case TypeRole.ARCHER:
                    if (Archers.Count < 1) return;
                    Archers.RemoveAt(0);
                    OnArcherAmountChanged?.Invoke(this, Archers.Count);
                    break;
                case TypeRole.MAGE:
                    if (Mages.Count < 1) return;
                    Mages.RemoveAt(0);
                    OnMageAmountChanged?.Invoke(this, Mages.Count);
                    break;
            }
        }
    }

    public class BaseUnit : Unit
    {
        public override string GetSign()
        {
            throw new NotImplementedException();
        }
    }
}
