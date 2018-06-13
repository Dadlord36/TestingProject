using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public abstract class InvCell : MonoBehaviour
{
    Image image;
    protected bool holdsItem;
    readonly Color transparentColor = new Color (0,0,0,0);

    public void Prepere()
    {
        SubscribeOnClick(ButtonClick);
        image = GetComponent<Image>();
    }

    public virtual void Clear()
    {
        image.sprite = null;
        image.color= transparentColor;
        holdsItem = false;
    }

    public virtual void SetItemToHold(ref uint itemId)
    {
        image.color = Color.white;
        var itemData = GameData.Instance.GetItemData(ref itemId);
        image.sprite = itemData.sprite;
        holdsItem = true;
    }
    public void SetItemToHold(uint itemId)
    {
        SetItemToHold(ref itemId);
    }
    public void SubscribeOnClick(UnityEngine.Events.UnityAction action )
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(action);
    }

    protected abstract void ButtonClick();

}
