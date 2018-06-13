using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class BaseInteraction : BaseClass
{
    protected PolygonCollider2D polyCollider;
    virtual protected void Awake()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
    }
}
