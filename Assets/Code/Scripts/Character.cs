using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Character : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        var itemInvCells = FindObjectsOfType<ItemInvCell>();
        var mainInvCell = FindObjectOfType<MainInvCell>();
        new Inventory(itemInvCells, mainInvCell);

        foreach (var cell in itemInvCells)
        {
            cell.Clear();
        }
        mainInvCell.Clear();
    }
}
