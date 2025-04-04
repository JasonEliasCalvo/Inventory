using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> _items = new()
    {
        {0,15}, {1,10}, {2,1}, {3,5}, {4,15}, {5,25}, {6,5}, {7,20}, {8,4}, {9,6}, {10,30},{11,5}
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    private void Start()
    {
        ShowInventory();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            SaveItem(1,5);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            RemoveItem(1,5);
        }
    }

    public void SaveItem(int id, int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] += amount;
        }
        else
        {
            Items.Add(id, amount);
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
            ShowInventory();
            if (_items[id] <= 0)
            {
                _items.Remove(id);
                Debug.Log("Se borro");
            }
        }
    }
}
