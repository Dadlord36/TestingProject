using UnityEngine;
using UnityEngine.SceneManagement;

sealed class PlaceEntry  : BaseInteraction<DelegatesCollections.DummyStruct>/*, IMainObjectsReceiver*/
{
    /// <summary>
    /// Index of represented scene
    /// </summary>
    [SerializeField]
    uint representedScene;
    private GameManager gameManager;

    public override void Prepere(uint level)
    {
        //throw new System.NotImplementedException();
    }

    //public void ReciveGameManager(GameManager gameManager)
    //{
    //    this.gameManager=gameManager;
    //}

    private void OnMouseDown()
    {
        SceneManager.LoadScene((int)representedScene);
    }
}

