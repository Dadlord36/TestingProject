
using UnityEngine;

public class GameData
{
    public static GameData instance;
    Items itemsData;
    public GameData()
    {
        itemsData = Resources.Load<Items>("ItemsData") as Items;
        if (itemsData != null)
            Debug.Log("Data was loaded");
        else
        {
            Debug.Log("Data was NOT loaded");

        }
        instance = this;
    }

    public ItemData GetItemData(ref uint itemId)
    {
        return itemsData.GetItemData(ref itemId);
    }
}

