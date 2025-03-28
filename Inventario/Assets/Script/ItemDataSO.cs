using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataSO : ScriptableObject
{
    [SerializeField]string _itemName;
    [SerializeField]Sprite _sprite;
    [SerializeField]GameObject _prefab;
    [SerializeField]int _id;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
    public int Id { get => _id; set => _id = value; }
}
