using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PassiveAbilityConfig", menuName = "ScriptableObjects/Configs/PassiveAbilityConfig")]
    [Serializable]
    public class PassiveAbilityConfig : ScriptableObject, IPassiveAbility
    {
        [field: SerializeField] public decimal Coefficient { get; set; }
        [field: SerializeField] public string Description { get; set; }
        [field: SerializeField] public bool IsHeal { get; set; }
        
        public IUnit Unit { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
