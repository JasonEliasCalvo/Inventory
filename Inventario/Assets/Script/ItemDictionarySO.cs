using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class IntIntPair
{
    public int key;
    public int value;
}

[CreateAssetMenu(fileName = "ItemDictionary", menuName = "Item Dictionary")]
public class ItemDictionarySO : ScriptableObject
{
    public List<IntIntPair> items;

    public Dictionary<int, int> ToDictionary()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (var pair in items)
        {
            if (!dict.ContainsKey(pair.key))
            {
                dict.Add(pair.key, pair.value);
            }
            else
            {
                Debug.LogWarning($"Duplicate key {pair.key} found in {name}, skipping.");
            }
        }
        return dict;
    }
}
