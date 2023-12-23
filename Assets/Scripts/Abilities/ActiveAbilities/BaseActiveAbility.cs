using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abilities.ActiveAbilities
{
    public class BaseActiveAbility : AbstractActiveAbility
    {
        public BaseActiveAbility(int cost, string description, decimal coefficient, bool isHeal) : base(cost, description, coefficient, isHeal)
        {
        }
    }
}
