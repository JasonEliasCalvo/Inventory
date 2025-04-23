using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void InventoryDelagat();
    public InventoryDelagat ItemAdded;
    public InventoryDelagat ItemRemoved;
    public InventoryDelagat ItemUpdated;

    public ItemDictionarySO ItemDictionary;

    Dictionary<int, int> _items = new();

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    private void Awake()
    {
        if (ItemDictionary != null)
        _items = ItemDictionary.ToDictionary();
    }

    private void Start()
    {  
        ShowInventory();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            AddItem(1,5);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            RemoveItem(1,5);
        }
    }

    public void AddItem(int id, int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] += amount;
            ItemUpdated?.Invoke();
        }
        else
        {
            Items.Add(id, amount);
            ItemAdded?.Invoke();
        }

        ShowInventory();
    }

    public void ShowInventory()
    {
        foreach (var item in Items)
        {
            Debug.Log("ID: " + item.Key + " Cantidad: " + item.Value);
        }
    }

    public void RemoveItem(int id, int amount)
    {
        if (_items.ContainsKey(id))
        {
            _items[id] -= amount;

            if (_items[id] <= 0)
            {
                _items.Remove(id);
                ItemRemoved?.Invoke();
            }
            else
            {
                ItemUpdated?.Invoke();
            } 
        }
    }
}
