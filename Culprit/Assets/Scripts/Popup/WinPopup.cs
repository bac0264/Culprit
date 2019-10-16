using UnityEngine;
using System.Collections;

public class WinPopup : BasePopup
{
    public static WinPopup instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            HidePopup();
        }
    }
    public override void ShowPopup()
    {
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
}
