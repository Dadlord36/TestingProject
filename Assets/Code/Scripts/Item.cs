using UnityEngine;

public class Item : SpriteInteraction
{
    [SerializeField]
    public uint itemID;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Inventory.Instance.PickupItem(this);
        Destroy(this);
    }

    //protected override void Initialize(Items itemsData)
    //{
    //    mainSpriteRenderer.sprite = itemsData.GetItemData(ref itemID).sprite;
    //}
}
