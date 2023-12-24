using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abilities.PassiveAbilities
{
    public abstract class AbstractPassiveAbility : IPassiveAbility
    {
        private string _description;
        private decimal _coefficient;

        public decimal Coefficient
        {
            get { return _coefficient; }
            set { if (value < 0) throw new ArgumentOutOfRangeException("Coefficient не может быть отрицательным"); _coefficient = value; }
        }

        public string Description
        {
            get { return _description; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Description не может быть null или empty"); _description = value; }
        }

        public AbstractPassiveAbility(string description, decimal coefficient)
        {
            Description = description;
            Coefficient = coefficient;
        }

        public abstract void Execute(IUnit unit);
    }
}
