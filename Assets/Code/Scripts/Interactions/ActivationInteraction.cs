using UnityEngine;


public struct InteractionData
{
    /// <summary>
    /// Is interaction happens already and can't be done again 
    /// </summary>

    public uint interactionId;
    [HideInInspector]
    public bool happens;

    public static bool operator ==(InteractionData a, InteractionData b)
    {
        return a.interactionId == b.interactionId;
    }
    public static bool operator !=(InteractionData a, InteractionData b)
    {
        return a.interactionId != b.interactionId;
    }
}

sealed public class ActivationInteraction : RequirementInteraction<DelegatesCollections.DummyStruct>
{
    [SerializeField]
    private InteractionData interactionData;
    bool isActivated;

    override protected void Awake()
    {
        base.Awake();
    }

    public override void Prepere(uint level)
    {
        TryLoadSelf();
    }

    void TryLoadSelf()
    {
        if (!GameData.Instance.TryLoad(ref interactionData))
        {
            return;
        }
        MakeAction();
    }

    private void OnMouseDown()
    {
        if (IsAcceptRequirement())
        {
            if (!isActivated)
            {
                MakeAction();
                Inventory.Instance.UseSelectedItem();
                RegistrateInteraction();
                interactionData.happens = true;
            }
        }
    }

    void MakeAction()
    {
        SwitchChildActiveEnable(true);
        var items = GetComponentsInChildren<Item>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActivity(!items[i].ItemParameters.pickedup);
        }
        polyCollider.enabled = false;
    }

    void RegistrateInteraction()
    {
        GameData.Instance.Register(ref interactionData);
    }

    void SwitchChildActiveEnable(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
        isActivated = state;
    }

 
}
