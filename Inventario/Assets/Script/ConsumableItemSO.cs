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
    [SerializeField] int _valor;
    [SerializeField] ConsumableType _type;

    public int Valor { get => _valor; set => _valor = value; }
    public ConsumableType Type { get => _type; set => _type = value; }
}
