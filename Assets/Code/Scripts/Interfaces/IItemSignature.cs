
namespace Interfaces.Signatures
{
    interface IItemSignature
    {
        void OnItemPicked(ref uint itemId);
        /// <summary>
        /// Subscribe listener to events of the item
        /// </summary>
        /// <param name="itemDelegates"> Item delegates collection </param>
        void SubscriveOnItemEvents(ref DelegatesCollections.ItemDelegates itemDelegates);
    }
}
