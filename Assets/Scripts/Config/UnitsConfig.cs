using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting;

[CreateAssetMenu(fileName = "UnitsConfig", menuName = "ScriptableObjects/Configs/UnitsConfig")]
public class UnitsConfig : ScriptableObject
{
    [field : SerializeField] public UnitConfig[] Humans {  get; private set; }
    [field: SerializeField] public UnitConfig[] Orcs { get; private set; }
    [field: SerializeField] public UnitConfig[] Undeads { get; private set; }

    public List<UnitConfig> UnitConfigs => Humans.Concat(Orcs).Concat(Undeads).ToList();

    public UnitConfig[] GetByFaction(TypeFaction typeFaction)
    {
        return typeFaction switch
        {
            TypeFaction.HUMANS => Humans,
            TypeFaction.ORCS => Orcs,
            TypeFaction.UNDEADS => Undeads,
            _ => null,
        };
    }

    public UnitConfig GetByID(int id)
    {
        foreach (UnitConfig unitConfig in UnitConfigs)
        {
            if (unitConfig.ID == id) return unitConfig;
        }

        return null;
    }
}

[Serializable]
public class UnitConfig : IUnitStats
{
    public int ID;

    public Sprite Sprite;

    [field: SerializeField] public string Name { get; set; }

    [field: SerializeField, TextArea] public string Description { get; set; }

    [field: SerializeField] public decimal MaxHealth { get; set; }
    [field: SerializeField] public decimal CurrentHealth { get; set; }

    [field: SerializeField] public decimal Power { get; set; }

    [field: SerializeField] public int Armor { get; set; }

    [field: SerializeField] public int DistanceOfMove { get; set; }
    [field: SerializeField] public int Initiative { get; set; }

    [field: SerializeField] public int AmountEnergy { get; set; }
    [field: SerializeField] public decimal MaxEnergy { get; set; }
    [field: SerializeField] public decimal CurrentEnergy { get; set; }

    [field: SerializeField] public List<IPassiveAbility> PassiveAbilities { get; set; }
    [field: SerializeField] public List<IActiveAbility> ActiveAbilities { get; set; }
}
