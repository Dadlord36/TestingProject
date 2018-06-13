
sealed public class ActivationInteraction : RequirementInteraction
{
    override protected void Awake()
    {
        base.Awake();
        SwitchChildActiveEnable(false);
    }
    bool isActivated;

    private void OnMouseDown()
    {
        if (IsAcceptRequirement())
        {
            if (!isActivated)
            {
                SwitchChildActiveEnable(true);
                polyCollider.enabled = false;
                Inventory.Instance.UseSelectedItem();
            }
        }
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
