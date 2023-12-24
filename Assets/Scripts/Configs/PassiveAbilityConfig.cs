using Assets.Scripts.Abilities.ActiveAbilities;
using Assets.Scripts.Abilities.PassiveAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [Serializable]
    public abstract class PassiveAbilityConfig : ScriptableObject, IPassiveAbility
    {
        [SerializeField] private double _coefficient;
        public decimal Coefficient { get => (decimal)_coefficient; set { } }

        [field: SerializeField] public string Description { get; set; }

        public abstract void Execute(IUnit unit);
    }
}
