using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    ItemDatabaseSO itemDatabaseIF;

    public ItemFactory(ItemDatabaseSO databaseTemp) 
    {
        itemDatabaseIF = databaseTemp;
    }

    public void CreateItem(int id, Vector3 position, Transform parent)
    {
        ItemDataSO searchItem = itemDatabaseIF.SearchById(id);
        GameObject instantiateItem = Instantiate(searchItem.Prefab, parent);
        instantiateItem.transform.position = position;
    }

    public void Initialize(ItemDatabaseSO item)
    {
        itemDatabaseIF = item;
    }
}
