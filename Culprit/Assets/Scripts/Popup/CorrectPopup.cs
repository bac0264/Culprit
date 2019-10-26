using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CorrectPopup : BasePopup
{
    public static CorrectPopup instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public Text Explanation;

    public override void ShowPopup()
    {
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
}
