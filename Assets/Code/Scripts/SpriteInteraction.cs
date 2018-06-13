using Interfaces;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class SpriteInteraction<DelegatesCollectionType> : BaseInteraction<DelegatesCollectionType>
{
    protected SpriteRenderer mainSpriteRenderer;


    protected override void Awake()
    {
        base.Awake();
        mainSpriteRenderer = GetComponent<SpriteRenderer>();
        //Initialize(GameData.instance.itemsData);
    }

    //protected abstract void Initialize(Items itemsData) ;

    public override void SetActivity(bool active)
    {
        base.SetActivity(active);
        mainSpriteRenderer.enabled = active;
    }

    protected virtual void OnMouseDown()
    {
        //Debug.Log(mainSpriteRenderer.sprite.name);
    }
}
