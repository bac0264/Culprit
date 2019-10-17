using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadUnitOnvalidate : MonoBehaviour
{
    public static LoadUnitOnvalidate instance;
    public Transform unitContainer;
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
                stageManager.LoadUnit(unitList);
            }
        }
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
                GameObject obj = Instantiate(unit.gameObject, transform);
                obj.SetActive(true);
                Unit _unit = obj.GetComponent<Unit>();
                markedUnit.Add(_unit);
                return _unit;
            }
        }
        return null;
    }
}
