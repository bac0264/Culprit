using UnityEngine;
using System.Collections;

public class WinPopup : BasePopup
{
    public static WinPopup instance;
    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
    public override void Try()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        Debug.Log(unitStage.unit);
        if (unitStage.unit != null)
        {
            unitStage.unit.Try();
        }
        HidePopup();
    }
    public override void Next()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        if (StageManager.instance != null && unitStage.unit != null)
            StageManager.instance.NextLevel(unitStage);
        HidePopup();
    }
}
