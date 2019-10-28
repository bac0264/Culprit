using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnhancedScrollerDemos.SuperSimpleDemo;

public class LoadUnitOnvalidate : MonoBehaviour
{
    public static LoadUnitOnvalidate instance;
    public Transform unitContainer;
    public Transform unitMode2Container;
    public StageManager stageManager;
    public Unit[] unitList;
    public List<Unit> markedUnit;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void OnValidate()
    {
        if (unitContainer == null) unitContainer = this.transform;
        if (stageManager == null) stageManager = FindObjectOfType<StageManager>();
        if (unitList.Length == 0)
        {
            unitList = Resources.LoadAll<Unit>("Level");
            if (stageManager != null)
            {
                //  stageManager.LoadUnit(unitList);
            }
        }
    }
    public int GetAmountStage()
    {
        int max = 0;
        for (int j = 0; j < unitList.Length; j++)
        {
            if (unitList[j].indexStage > max)
            {
                max = unitList[j].indexStage;
            }
        }
        return (max + 1);
    }
    public int GetAmountUnitStage(int index)
    {
        int amount = 0;
        for (int j = 0; j < unitList.Length; j++)
        {
            if (unitList[j].indexStage == index)
            {
                amount++;
            }
        }
        return amount;
    }
    public Unit GetUnitFromResources(int indexStage, int indexUnitstage)
    {
        if (markedUnit.Count > 0)
        {
            foreach (Unit unit in markedUnit)
            {
                if (unit.indexStage == indexStage && unit.indexUnit == indexUnitstage)
                {
                    unit.gameObject.SetActive(true);
                    return unit;
                }
            }
        }
        foreach (Unit unit in unitList)
        {
            if (unit.indexStage == indexStage && unit.indexUnit == indexUnitstage)
            {
                GameObject obj = null;
                if (unit is UnitMode1)
                {
                    obj = Instantiate(unit.gameObject, unitContainer);
                }
                else if (unit is UnitMode2)
                {
                    obj = Instantiate(unit.gameObject, unitMode2Container);
                }
                obj.SetActive(true);
                Unit _unit = obj.GetComponent<Unit>();
                markedUnit.Add(_unit);
                return _unit;
            }
        }
        return null;
    }
}
