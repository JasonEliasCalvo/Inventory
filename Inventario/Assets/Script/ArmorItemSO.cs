using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{
    Head,
    Chest,
    Legs,
    Foot,
    Face,
    Backpack,
}

[CreateAssetMenu(fileName = "new Armor", menuName = "newItem/Armor")]
public class ArmorItemSO : ItemDataSO
{
    [SerializeField] int _valor;
    [SerializeField] ArmorType _type;

    public int Valor { get => _valor; set => _valor = value; }
    public ArmorType Type { get => _type; set => _type = value; }
}
