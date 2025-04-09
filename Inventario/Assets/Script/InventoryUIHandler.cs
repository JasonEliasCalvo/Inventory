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
    [SerializeField] TextMeshProUGUI itemAmountPreview;

    [SerializeField] Image itemImagePreview;
    int itemSelectedId;

    List<GameObject> instantiatedButtonslist = new();

    [SerializeField] CanvasGroup previewPanel;

    public void Start()
    {
        SetInventory(inventory);
        InstantiateButtons();
        Showtems();
    }

    public void SetInventory(Inventory newInventory)
    {
        // me desuscribo a los eventos del inventario anterior
        if (inventory != null)
        {
            inventory.ItemAdded -= Showtems;
            inventory.ItemUpdated -= Showtems;
            inventory.ItemUpdated -= UpdateAmountPreview;
            inventory.ItemRemoved -= Showtems;
            inventory.ItemRemoved -= HidePreviewPanel;
        }

        //cambio inventario
        inventory = newInventory;

        // me desuscribo a los eventos del inventario nuevo
        inventory.ItemAdded += Showtems;
        inventory.ItemUpdated += Showtems;
        inventory.ItemUpdated += UpdateAmountPreview;
        inventory.ItemRemoved += Showtems;
        inventory.ItemRemoved += HidePreviewPanel;
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
            searchedbutton.GetComponent<StandarInventaryButton>().SetButtonAction(() => ShowItemPreview(itemData, item.Value.ToString()));
            searchedbutton.GetComponent<StandarInventaryButton>().SetButtonAction(() => ShowPreviewPanel());
        }
    }

    private void ShowItemPreview(ItemDataSO itemDataTemp, string amount)
    {
        itemSelectedId = itemDataTemp.Id;
        itemNamePreview.text = itemDataTemp.name;
        itemImagePreview.sprite = itemDataTemp.Sprite;  
        itemDescriptionPreview.text = itemDataTemp.Description;
        itemAmountPreview.text = amount;
    }

    public void DeleteItem()
    {
        inventory.RemoveItem(itemSelectedId, 1);
    }

    private void UpdateAmountPreview()
    {
        itemAmountPreview.text = inventory.Items[itemSelectedId].ToString();
    }

    public void ShowPreviewPanel()
    {
        previewPanel.alpha = 1.0f;
        previewPanel.interactable = true;
        previewPanel.blocksRaycasts = true;
    }
    public void HidePreviewPanel()
    {
        previewPanel.alpha = 0.2f;
        previewPanel.interactable = false;
        previewPanel.blocksRaycasts = false;
    }
}
