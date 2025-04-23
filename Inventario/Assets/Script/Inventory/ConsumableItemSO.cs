using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Heal,
    Poison,
    Damage,
    Util,
}

[CreateAssetMenu(fileName = "new Consumable", menuName = "newItem/Comsumable")]

public class ConsumableItemSO : ItemDataSO
{
    [Space(10)]
    [Header("Comsumable Data")]

    [SerializeField] int _value;
    [SerializeField] ConsumableType consumableType;

    public void OnEnable()
    {
        ItemType = ItemTypeEnum.consumable;
    }

    public int Value { get => _value; set => _value = value; }
    public ConsumableType ConsumableType { get => consumableType; set => consumableType = value; }
}
