using Interfaces;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class SpriteInteraction : BaseInteraction
{
    protected SpriteRenderer mainSpriteRenderer;


    protected override void  Awake()
    {
        base.Awake();
        mainSpriteRenderer = GetComponent<SpriteRenderer>();
        //Initialize(GameData.instance.itemsData);
    }

    //protected abstract void Initialize(Items itemsData) ;

    protected virtual void OnMouseDown()
    {
        //Debug.Log(mainSpriteRenderer.sprite.name);
    }
}
