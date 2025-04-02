using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> _items = new()
    {
        {0,15}, {1,10}, {2,1}, {3,5}, {4,15}, {5,25}, {6,5}, {7,20}, {8,4}, {9,6}, {10,30},
    } ;

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        SaveItem(0, 1);
    //    }
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        SaveItem(1, 1);
    //    }
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        SaveItem(2, 1);
    //    }
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        SaveItem(3, 1);
    //    }
    //}

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
}
