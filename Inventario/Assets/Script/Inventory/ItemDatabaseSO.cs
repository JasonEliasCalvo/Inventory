using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database SO", menuName = "New Items Database SO")]
public class ItemDatabaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> _items = new();

    public List<ItemDataSO> Items { get => _items; set => _items = value; }

    public ItemDataSO SearchById(int id)
    {
        return Items.FirstOrDefault(x => x.Id == id);
    }
}
