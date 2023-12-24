using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abilities.PassiveAbilities
{
    public class BasePassiveAbility : AbstractPassiveAbility
    {
        public BasePassiveAbility(string description, decimal coefficient) 
            : base(description, coefficient)
        {

        }

        public override void Execute(IUnit unit)
        {
            throw new NotImplementedException();
        }
    }
}
