using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database SO", menuName = "New Items Database SO")]
public class ItemDatabaseSO : ScriptableObject
{
    [SerializeField]List<ItemDataSO> items = new();
}
