using UnityEngine;
using System.Collections;
using EnhancedScrollerDemos.SuperSimpleDemo;
using System.Collections.Generic;

public class BlockUnitStage : CellView
{
    public UnitStage[] unitstageList;
    private void OnValidate()
    {
        if (unitstageList.Length == 0) unitstageList = GetComponentsInChildren<UnitStage>();
    }
    public override void SetData(List<Data> data)
    {
        int i = 0;
        for (; i < unitstageList.Length && i < data.Count; i++)
        {
            unitstageList[i].gameObject.SetActive(true);
            unitstageList[i].SetData(data[i]);
        }
        for (; i < unitstageList.Length; i++)
        {
            unitstageList[i].gameObject.SetActive(false);
        }
    }
}
