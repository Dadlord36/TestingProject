using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    uint beginScene = 1;
    [SerializeField]
    PreviewWindow previewWindow;
    ReturnButton returnButton;
    private uint prevScene;

    private void Awake()
    {
        var baseObjects = FindObjectsOfType<BaseMonoClass>();
        foreach (var item in baseObjects)
        {
            if (item is Interfaces.ICore)
                (item as Interfaces.ICore).OnAwake();
        }

        returnButton = FindObjectOfType<ReturnButton>();
        SceneManager.sceneLoaded += SceneLoaded;
        DontDestroyOnLoad(this);
    }

    private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        List<BaseMonoClass> baseObjects = new List<BaseMonoClass>(FindObjectsOfType<Item>());
        baseObjects.AddRange(FindObjectsOfType<ActivationInteraction>());
        for (int i = 0; i < baseObjects.Count; i++)
        {
            baseObjects[i].Prepere((uint)arg0.buildIndex);
        }

        var sceneData = FindObjectOfType<SceneData>();
        if (sceneData != null)
        {
            prevScene = sceneData.goBackToScene;
            returnButton.CanReturn = true;
        }

        else
        {
            returnButton.CanReturn = false;
        }
    }


    private void Start()
    {
        var baseObjects = FindObjectsOfType<BaseMonoClass>();
        foreach (var item in baseObjects)
        {
            if (item is Interfaces.ICore)
                (item as Interfaces.ICore).OnStart();

        }
        SceneManager.LoadScene((int)beginScene);
        Inventory.Instance.delegates.onItemWasPickedUp += ItemWasPickedUp;

    }

    // Load the previous scene, that this scene current referencing to
    public void GoToPreviousScene()
    {
        SceneManager.LoadScene((int)prevScene);
    }

    private void ItemWasPickedUp(ref uint itemId)
    {
        previewWindow.ShowItemPreview(ref itemId);
    }
}
