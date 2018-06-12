
using System;
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
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneWasLoaded;
        new GameData();
    }
    private void Start()
    {
        SceneManager.LoadScene((int)beginScene);
        Inventory.instance.onItemWasPickedUp += ItemWasPickedUp;

    }

    private void ItemWasPickedUp(ref uint itemId)
    {
        previewWindow.ShowItemPreview(ref itemId);
    }

    private void OnSceneWasLoaded(Scene arg0, LoadSceneMode arg1)
    {

    }




}
