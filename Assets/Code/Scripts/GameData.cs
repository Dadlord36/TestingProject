
using UnityEngine;

public class GameData
{
    Items itemsData;
    private GameData()
    {
        itemsData = Resources.Load<Items>("ItemsData") as Items;
        if (itemsData != null)
            Debug.Log("Data was loaded");
        else
        {
            Debug.Log("Data was NOT loaded");

        }
        Instance = this;
    }

    public static GameData Instance { get;private set; } = new GameData();

    public ItemData GetItemData(ref uint itemId)
    {
        return itemsData.GetItemData(ref itemId);
    }
}

