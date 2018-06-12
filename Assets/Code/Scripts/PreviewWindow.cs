using UnityEngine;
using UnityEngine.UI;

public class PreviewWindow : MonoBehaviour {

    [SerializeField]
    Image previewPreview;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowItemPreview(ref uint itemId)
    {       
        previewPreview.sprite= GameData.instance.GetItemData(ref itemId).sprite;
        gameObject.SetActive(true);
    }
}
