using DelegatesCollections;
using Interfaces.Signatures;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :BaseBehaviour<DelegatesCollections.InventoryDelegates> ,IItemSignature
{
    public static Inventory Instance { get; } = new Inventory();

    List<uint> items;
    ItemInvCell[] itemsCells = new ItemInvCell[maxItems];
    MainInvCell mainCell;
    GameData previewWindow;
    uint selectedCellIndex;
    bool settedup;
    public uint SelectedItemId { get; private set; }
    public bool ItemIsSelected { get; private set; }
    
    public void UseSelectedItem()
    {
        mainCell.Clear();
        itemsCells[selectedCellIndex].Clear();
        filledCells--;
    }

    const uint maxItems = 7;
    uint filledCells;

    Inventory()
    {
        items = new List<uint>((int)maxItems);
    }

    public void SetupInventory(ItemInvCell[] itemsCells, MainInvCell mainCell)
    {
        if (!settedup)
        {
            this.itemsCells = itemsCells;
            foreach (var cell in itemsCells)
            {
                cell.Prepere();
            }
            SortCells();
            this.mainCell = mainCell;
            mainCell.Prepere();
        }
        else
        {
            Debug.Log("Inventory is already setts");
        }
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
        SelectedItemId = holdedItemId;
        ItemIsSelected = true;
        mainCell.SetItemToHold(ref holdedItemId);
    }

    public void OnItemPicked(ref uint itemId)
    {
        if (filledCells < maxItems)
        {
            items.Add(itemId);
            itemsCells[filledCells].SetItemToHold(itemId);
            filledCells++;
            delegates.onItemWasPickedUp(ref itemId);
        }
    }

    public void SubscriveOnItemEvents(ref ItemDelegates itemDelegates)
    {
        itemDelegates.onItemWasPickedUp += OnItemPicked;
    }
}
