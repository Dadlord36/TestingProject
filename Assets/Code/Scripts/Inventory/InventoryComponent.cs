using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Animation))]
public class InventoryComponent : BaseMonoBehaviour<DelegatesCollections.DummyStruct>, ICore
{
    private Animation inventoryCellsAnimation;
    [SerializeField]
    MainInvCell mainCell;
    bool slidedDown=false;
    [SerializeField]
    AnimationClip[] slideAnimationClips = new AnimationClip[2];
    [SerializeField]
    Image blockingImage;
    private const string animStartTriggerName = "Slide";

    public void OnStart()
    {
        PlaySlideAnimation();
    }

    public void OnAwake()
    {
        Prepere();
    }

    private void Prepere()
    {
        DontDestroyOnLoad(this);

        blockingImage.raycastTarget = false;

        inventoryCellsAnimation = GetComponent<Animation>();
        var itemInvCells = FindObjectsOfType<ItemInvCell>();
        var mainInvCell = FindObjectOfType<MainInvCell>();
        Inventory.Instance.SetupInventory(itemInvCells, mainInvCell);
        mainCell.SubscribeOnClick(PlaySlideAnimation);

        var newAmimEnvent = new AnimationEvent();
        newAmimEnvent.functionName = "OnAnimationEvent";
        newAmimEnvent.time = slideAnimationClips[0].length;
        foreach (var clip in slideAnimationClips)
        {

            clip.AddEvent(newAmimEnvent);
        }

        foreach (var cell in itemInvCells)
        {
            cell.Clear();
        }
        mainInvCell.Clear();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void Prepere(uint level)
    {
        
    }


    public void OnAnimationEvent(InventoryComponent inventoryComponent)
    {
        Debug.Log("Was triggered");
        slidedDown = !slidedDown;
        blockingImage.raycastTarget = false;
    }

    void PlaySlideAnimation()
    {
        if (!inventoryCellsAnimation.isPlaying)
        {
            if (slidedDown)
                inventoryCellsAnimation.Play("InventoryCellsSlide_Up");
                    else
                inventoryCellsAnimation.Play("InventoryCellsSlide_Down");
            blockingImage.raycastTarget = true;

        }
    }


}
