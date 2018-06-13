using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class BaseInteraction<DelegatesCollectionType> : BaseMonoBehaviour<DelegatesCollectionType>
{
    protected PolygonCollider2D polyCollider;
    virtual protected void Awake()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
    }
    virtual public void SetActivity(bool active)
    {
        polyCollider.enabled = active;
    }
}
