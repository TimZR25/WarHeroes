using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abilities.PassiveAbilities
{
    public abstract class AbstractPassiveAbility : IPassiveAbility
    {
        private IUnit _unit;
        private string _description;
        private decimal _coefficient;

        public decimal Coefficient
        {
            get { return _coefficient; }
            set { if (value < 0) throw new ArgumentOutOfRangeException("Coefficient не может быть отрицательным"); _coefficient = value; }
        }

        public IUnit Unit
        {
            get { return _unit; }
            set { if (_unit == null) throw new ArgumentNullException("Unit не может быть null"); _unit = value; }
        }

        public string Description
        {
            get { return _description; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Description не может быть null или empty"); _description = value; }
        }

        public bool IsHeal { get; set; }

        public AbstractPassiveAbility(IUnit unit, string description, decimal coefficient, bool isHeal)
        {
            Unit = unit;
            Description = description;
            Coefficient = coefficient;
            IsHeal = isHeal;
        }

        public void Execute()
        {
            if (Unit.Stats.Armor + Coefficient >= Unit.Stats.MaxArmor) { Unit.Stats.Armor = Unit.Stats.MaxArmor; }
            else { Unit.Stats.Armor = Unit.Stats.Armor + (int)Coefficient; }
        }
    }
}
