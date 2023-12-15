using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting;

[CreateAssetMenu(fileName = "UnitsConfig", menuName = "ScriptableObjects/UnitsConfig")]
public class UnitsConfig : ScriptableObject
{
    public UnitConfig[] Humans;
    public UnitConfig[] Orcs;
    public UnitConfig[] Undeads;

    public UnitConfig[] GetConfigByFaction(TypeFaction typeFaction)
    {
        return typeFaction switch
        {
            TypeFaction.HUMANS => Humans,
            TypeFaction.ORCS => Orcs,
            TypeFaction.UNDEADS => Undeads,
            _ => null,
        };
    }
}

[Serializable]
public class UnitConfig : IUnitStats
{
    [field: SerializeField] public IUnitStats UnitStats;

    public Sprite Sprite;

    [field: SerializeField] public string Name { get; set; }

    [field: SerializeField] public decimal MaxHealth { get; set; }

    [field: SerializeField] public decimal CurrentHealth { get; set; }
    [field: SerializeField] public decimal Power { get; set; }
    [field: SerializeField] public int Armor { get; set; }
    [field: SerializeField, TextArea] public string Description { get; set; }
    [field: SerializeField] public int DistanceOfMove { get; set; }
    [field: SerializeField] public int Initiative { get; set; }

    [field: SerializeField] public int Score { get; set; }

    [field: SerializeField] public int AmountEnergy { get; set; }
}
