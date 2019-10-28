using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LosePopup : BasePopup
{
    public static LosePopup instance;
    public List<GameObject> loseImageList;
    public Transform containerLoseImageList;
    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnValidate()
    {
        if(loseImageList.Count == 0)
        {
            for(int i = 0; i < containerLoseImageList.childCount; i++)
            {
                GameObject obj = containerLoseImageList.GetChild(i).gameObject;
                obj.SetActive(false);
                loseImageList.Add(obj);
            }
        }
    }
    public override void ShowPopup()
    {
        RandomImageLose();
        base.ShowPopup();
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }
    public void RandomImageLose()
    {
        int random = Random.Range(0, loseImageList.Count);
        loseImageList[random].SetActive(true);
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
}
