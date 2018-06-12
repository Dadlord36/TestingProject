using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnItemWasPickedUp(ref uint itemId);

public class Inventory
{
    public OnItemWasPickedUp onItemWasPickedUp;
   
    public static Inventory instance;
    List<uint> items;
    ItemInvCell[] itemsCells = new ItemInvCell[maxItems];
    readonly MainInvCell mainCell;
    GameData previewWindow;
    public uint SelectedItemId { get { return selectedItemId; } }
    uint selectedItemId;

    uint selectedCellIndex;

    public bool ItemIsSelected
    {
        get
        {
            return itemIsSelected;
        }
    }

 
    bool itemIsSelected;


    public void UseSelectedItem()
    {
        mainCell.Clear();
        itemsCells[selectedCellIndex].Clear();
        filledCells--;
    }

    const uint maxItems = 7;
    uint filledCells;

    public Inventory(ItemInvCell[] itemsCells, MainInvCell mainCell)
    {
        this.itemsCells = itemsCells;
        SortCells();
        this.mainCell = mainCell;
        items = new List<uint>((int)maxItems);
        instance = this;
    }

    private void SortCells()
    {
        ItemInvCell[] temp = new ItemInvCell[maxItems];
        for (int i = 0; i < itemsCells.Length; i++)
        {
            temp[(int)itemsCells[i].CellIndex]= itemsCells[i];
        }
        itemsCells = temp;

    }
    internal void SelectItem(ref uint holdedItemId, ref uint cellIndex)
    {
        selectedCellIndex = cellIndex;
        selectedItemId = holdedItemId;
        itemIsSelected = true;
        mainCell.SetItemToHold(ref holdedItemId);
    }

    public void PickupItem(Item item)
    {
        if (filledCells < maxItems)
        {
            AddItem(item);
            item.gameObject.SetActive(false);
            filledCells++;
            onItemWasPickedUp(ref item.itemID);
        }
    }

    private void AddItem(Item item)
    {
        items.Add(item.itemID);
        PlaceItemIconInCells(item);
    }

    void PlaceItemIconInCells(Item item)
    {
        itemsCells[filledCells].SetItemToHold(item.itemID);
    }

}
