using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database SO", menuName = "New Items Database SO")]
public class ItemDatabaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> items = new();

    public ItemDataSO SearchById(int id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }
}
