
using UnityEngine;
using UnityEngine.SceneManagement;

sealed class PlaceEntry  : BaseInteraction/*, IMainObjectsReceiver*/
{
    /// <summary>
    /// Index of represented scene
    /// </summary>
    [SerializeField]
    uint representedScene;
    private GameManager gameManager;
    //public void ReciveGameManager(GameManager gameManager)
    //{
    //    this.gameManager=gameManager;
    //}

    private void OnMouseDown()
    {
        SceneManager.LoadScene((int)representedScene);
    }
}

