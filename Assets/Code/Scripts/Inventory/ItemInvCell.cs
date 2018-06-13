using UnityEngine;
using System.Collections;


sealed public class ItemInvCell : InvCell
{
    [SerializeField]
    uint cellIndex;
    public uint CellIndex { get { return cellIndex; } }
    uint holdedItemId;
    public uint HoldedItemID { get { return holdedItemId;} }

    protected override void ButtonClick()
    {
        if(holdsItem)
        Inventory.Instance.SelectItem(ref holdedItemId, ref cellIndex);
    }

    public override void SetItemToHold(ref uint itemId)
    {
        base.SetItemToHold(ref itemId);
        holdedItemId = itemId;
    }

}
