using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDatabaseSO itemDatabase;

    [SerializeField] ScrollRect scrollItem;
    [SerializeField] GameObject prefabItem;

    public void Start()
    {
        InstantieItems();
    }

    public void Update()
    {

    }

    public void InstantieItems()
    {
        foreach (var item in inventory.Items)
        {
            ItemDataSO itemData = itemDatabase.SearchById(item.Key);

            GameObject instantiatebutton = Instantiate(prefabItem, scrollItem.content);
            instantiatebutton.GetComponent<StandarInventaryButton>().image.sprite = itemData.Sprite;
            instantiatebutton.GetComponent<StandarInventaryButton>().nameText.text = itemData.ItemName;
            instantiatebutton.GetComponent<StandarInventaryButton>().valueText.text = item.Value.ToString();
        }
    }
}
