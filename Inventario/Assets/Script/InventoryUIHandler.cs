using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDatabaseSO itemDatabase;

    [SerializeField] ScrollRect scrollItem;
    [SerializeField] GameObject prefabItem;

    [SerializeField] TextMeshProUGUI itemNamePreview;
    [SerializeField] TextMeshProUGUI itemDescriptionPreview;
    [SerializeField] Image itemImagePreview;
    int itemSelectedId;

    List<GameObject> instantiatedButtonslist = new();

    public void Start()
    {
        InstantiateButtons();
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            Showtems();
        }
    }

    public void InstantiateButtons()
    {
        for (int i = 0; i < itemDatabase.Items.Count; i++)
        {
            GameObject instantiatebutton = Instantiate(prefabItem, scrollItem.content);
            instantiatebutton.SetActive(false);
            instantiatedButtonslist.Add(instantiatebutton);
        }
    }

    public void Showtems()
    {
        for (int i = 0;i < instantiatedButtonslist.Count;i++)
        {
            instantiatedButtonslist[i].SetActive(false);
        }

        foreach (var item in inventory.Items)
        {
            ItemDataSO itemData = itemDatabase.SearchById(item.Key);

            GameObject searchedbutton = instantiatedButtonslist.Find(x => x.activeSelf == false);
            searchedbutton.SetActive(true);
            searchedbutton.GetComponent<StandarInventaryButton>().image.sprite = itemData.Sprite;
            searchedbutton.GetComponent<StandarInventaryButton>().nameText.text = itemData.ItemName;
            searchedbutton.GetComponent<StandarInventaryButton>().valueText.text = item.Value.ToString();
            searchedbutton.GetComponent<StandarInventaryButton>().SetButtonAction(() => ShowMoreInfo(itemData, item.Value.ToString()));
        }
    }

    private void ShowMoreInfo(ItemDataSO itemDataTemp, string amount)
    {
        itemSelectedId = itemDataTemp.Id;
        itemNamePreview.text = itemDataTemp.name;
        itemImagePreview.sprite = itemDataTemp.Sprite;  
        itemDescriptionPreview.text = itemDataTemp.Description;
    }

    public void DeleteItem()
    {
        inventory.RemoveItem(itemSelectedId, 1);
        Showtems();
    }
}
