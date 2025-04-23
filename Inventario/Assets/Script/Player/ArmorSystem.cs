using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class EquipedArmor
{
    [SerializeField] ArmorType _armorType;
    [SerializeField] Transform _armorPivot;
    [SerializeField] ArmorItemSO _armorData;
    [SerializeField] GameObject _armorGO;

    public ArmorType ArmorType { get => _armorType; set => _armorType = value; }
    public Transform ArmorPivot { get => _armorPivot; set => _armorPivot = value; }
    public ArmorItemSO ArmorData { get => _armorData; set => _armorData = value; }
    public GameObject ArmorGO { get => _armorGO; set => _armorGO = value; }
}

public class ArmorSystem : MonoBehaviour
{
    ItemFactory factory;
    [SerializeField] List<EquipedArmor> equipedArmor = new();
    [SerializeField] ItemDatabaseSO database;

    public void Start()
    {
        factory = gameObject.AddComponent<ItemFactory>();
        factory.Initialize(database);
    }

    public void EquipArmor(ArmorItemSO armorData)
    {
        EquipedArmor  armor = equipedArmor.Find(x => x.ArmorType == armorData.ArmorType);
        factory.CreateItem(armorData.Id, armor.ArmorPivot.position, armor.ArmorPivot);
    }

    public void RemoveEquip(ArmorItemSO armor)
    {

    }
}
