using System;
using UnityEngine;


[Serializable]
public struct ItemParameters
{
    public uint itemId;
    [HideInInspector]
    public bool pickedup;
    [HideInInspector]
    public uint levelWherePlaced;

    public static bool operator ==(ItemParameters a, ItemParameters b)
    {
        return a.levelWherePlaced == b.levelWherePlaced && a.itemId == b.itemId;
    }
    public static bool operator !=(ItemParameters a, ItemParameters b)
    {
        return a.levelWherePlaced != b.levelWherePlaced || a.itemId != b.itemId; ;
    }
}

public sealed class Item : SpriteInteraction<DelegatesCollections.ItemDelegates>
{
    [SerializeField]
    ItemParameters itemParameters;
    [SerializeField]
    bool startActive;

    public ItemParameters ItemParameters
    {
        get
        {
            return itemParameters;
        }
    }

    override public void Prepere(uint level)
    {
        itemParameters.levelWherePlaced = level;
        Inventory.Instance.SubscriveOnItemEvents(ref delegates);
        SetActivity(startActive);
        TryLoadSelf();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        gameObject.SetActive(false);
        if(delegates.onItemWasPickedUp==null)
            Debug.Log("no subscribers");
        delegates.onItemWasPickedUp(ref itemParameters.itemId);
        PickUp();

        Destroy(this);
    }

    private void PickUp()
    {
        RegisterSelf();
    }

    void RegisterSelf() => GameData.Instance.Register(ref itemParameters);

    void TryLoadSelf()
    {
        if (!GameData.Instance.TryLoad(ref itemParameters))
        {
            return;
        }
        SetActivity(false);
    }


    //protected override void Initialize(Items itemsData)
    //{
    //    mainSpriteRenderer.sprite = itemsData.GetItemData(ref itemID).sprite;
    //}
}
