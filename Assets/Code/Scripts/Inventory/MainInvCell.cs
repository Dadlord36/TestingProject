using UnityEngine;

public class MainInvCell : InvCell
{
    protected override void ButtonClick()
    {
        if (holdsItem)
        {
            Clear();
        }
    }
}