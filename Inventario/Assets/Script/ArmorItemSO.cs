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
    [Space(10)]
    [Header("Armor Data")]

    [SerializeField] int _value;
    [SerializeField] ArmorType armorType;

    public void OnEnable()
    {
        ItemType = ItemTypeEnum.Armor;
    }

    public int Value { get => _value; set => _value = value; }
    public ArmorType ArmorType { get => armorType; set => armorType = value; }
}
