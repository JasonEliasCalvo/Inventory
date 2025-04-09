using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponType
{
    Firearm,
    ColdWeapon,
}

[CreateAssetMenu(fileName = "new Weapon", menuName = "newItem/Weapon")]
public class WeaponItemSO : ItemDataSO
{
    [Space(10)]
    [Header("Weapon Data")]

    [SerializeField] int damage;
    [SerializeField] WeaponType weaponType;

    public void OnEnable()
    {
        ItemType = ItemTypeEnum.Weapon;
    }

    public int Damage { get => damage; set => damage = value; }
    public WeaponType WeaponType { get => weaponType; set => weaponType = value; }
}
