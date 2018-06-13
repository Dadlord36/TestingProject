using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RequirementInteraction: BaseInteraction
{
    /// <summary>
    /// ID of item, that required to make interaction possible
    /// </summary>
    [SerializeField]
    uint requiredItemID;

    /// <summary>
    /// Check if required item is selected in inventory
    /// </summary>
    /// <returns>Binary condition</returns>
    protected bool IsAcceptRequirement()
    {
        return Inventory.Instance.ItemIsSelected && requiredItemID == Inventory.Instance.SelectedItemId;
    }
}

