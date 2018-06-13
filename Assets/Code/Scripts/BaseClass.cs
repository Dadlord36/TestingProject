using UnityEngine;

public abstract class BaseMonoClass : MonoBehaviour
{
    public abstract void Prepere(uint level);
}

public abstract class BaseClass
{
}

/// <summary>
/// Base class, that represents behavior by delegates collection
/// </summary>
/// <typeparam name="DelegatesCollectionType"></typeparam>
public abstract class BaseBehaviour<DelegatesCollectionType> : BaseClass
{
    public DelegatesCollectionType delegates;

}

public abstract class BaseMonoBehaviour<DelegatesCollectionType> : BaseMonoClass
{
    public DelegatesCollectionType delegates;
}



