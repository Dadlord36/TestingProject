
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemData
{
    public uint id;
    public string name;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "ItemsData", menuName = "GamaName/Data")]
public class Items : ScriptableObject
{
    public List<ItemData> items;

    public ItemData GetItemData(ref uint itemID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id == itemID)
            {
                return items[i];
            }
        }
        throw new Exception("Item was not found");
    }
}
