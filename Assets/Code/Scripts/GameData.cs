

using System;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static GameData Instance { get; } = new GameData();
    
    Items itemsData;
    private List<ItemParameters> itemsRegister = new List<ItemParameters>();
    private List<InteractionData> interactionsRegister = new List<InteractionData>();

    private GameData()
    {
        itemsData = Resources.Load<Items>("ItemsData") as Items;
        if (itemsData != null)
            Debug.Log("Data was loaded");
        else
        {
            Debug.Log("Data was NOT loaded");
        }
    }


    public ItemData GetItemData(ref uint itemId) => itemsData.GetItemData(ref itemId);

    public void Register(ref ItemParameters itemParameters) => itemsRegister.Add(itemParameters);

    public void Register(ref InteractionData interactionData) => interactionsRegister.Add(interactionData);

    public bool IsRegistrated(ref ItemParameters itemParameters)
    {
        for (int i = 0; i < itemsRegister.Count; i++)
        {
            if (itemsRegister[i] == itemParameters)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsRegistrated(ref InteractionData interactionData)
    {
        for (int i = 0; i < interactionsRegister.Count; i++)
        {
            if (interactionsRegister[i] == interactionData)
            {
                return true;
            }
        }
        return false;
    }

    public bool TryLoad(ref InteractionData interactionData)
    {
        if (IsRegistrated(ref interactionData))
        {
            interactionData.happens = true;
            return true;
        }
        return false;
    }

    public bool TryLoad(ref ItemParameters itemParameters)
    {
        if (IsRegistrated(ref itemParameters))
        {
            itemParameters.pickedup = true;
            return true;
        }
        return false;
    }


}

