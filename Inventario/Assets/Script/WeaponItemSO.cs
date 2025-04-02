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
    [SerializeField] WeaponType type;

    public int Damage { get => damage; set => damage = value; }
    public WeaponType Type { get => type; set => type = value; }
}
