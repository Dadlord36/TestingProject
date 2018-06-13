

namespace DelegatesCollections
{
    public delegate void OnItemWasPickedUp(ref uint itemId);
    public delegate bool OnItemUse(Item item);


    public struct ItemDelegates
    {
        public OnItemWasPickedUp onItemWasPickedUp;
        public OnItemUse onUse;
    }

    public struct DummyStruct
    {   
    }

    public struct InventoryDelegates
    {
        public OnItemWasPickedUp onItemWasPickedUp;
    }
}