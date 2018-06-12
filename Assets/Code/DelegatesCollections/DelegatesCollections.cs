

namespace DelegatesCollections
{
    public delegate void OnItemPickingUp(Item item);
    public delegate bool OnItemUse(Item item);




    public struct PickupDelegates
    {
        public OnItemPickingUp onPickedUp;
        public OnItemUse onUse;
    }
    public struct MainObjectsDelegates
    {

    }

}