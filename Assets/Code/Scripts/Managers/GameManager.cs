
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    uint beginScene = 1;
    [SerializeField]
    PreviewWindow previewWindow;


    private void Awake()
    {
        var baseObjects = FindObjectsOfType<BaseClass>();
        foreach (var item in baseObjects)
        {
            if (item is Interfaces.ICore)
                (item as Interfaces.ICore).OnAwake();
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        var baseObjects = FindObjectsOfType<BaseClass>();
        foreach (var item in baseObjects)
        {
            if (item is Interfaces.ICore)
                (item as Interfaces.ICore).OnStart();
        }
        SceneManager.LoadScene((int)beginScene);
        Inventory.Instance.onItemWasPickedUp += ItemWasPickedUp;
    }

    private void ItemWasPickedUp(ref uint itemId)
    {
        previewWindow.ShowItemPreview(ref itemId);
    }
}
