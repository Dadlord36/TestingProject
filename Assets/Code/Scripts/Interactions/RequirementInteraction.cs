using UnityEngine;

public abstract class RequirementInteraction<DelegatesCollectionType> : BaseInteraction<DelegatesCollectionType>
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

