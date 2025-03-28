using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDatabaseSO itemDatabase;

    [SerializeField] ScrollRect scrollItem;
    [SerializeField] GameObject prefabItem;

    public void InstantieItems()
    {
        foreach (var item in inventory.Items)
        {
            Instantiate(prefabItem, scrollItem.content);
        }
    }
}
