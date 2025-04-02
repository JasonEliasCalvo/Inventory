using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataSO : ScriptableObject
{
    [Header("Base Data")]

    [SerializeField]string _itemName;
    [SerializeField]Sprite _sprite;
    [SerializeField]GameObject _prefab;
    [SerializeField]int _id;
    [SerializeField, TextArea (3,3)]string _description;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
    public int Id { get => _id; set => _id = value; }

    public string Description { get => _description; set => _description = value; }
}
