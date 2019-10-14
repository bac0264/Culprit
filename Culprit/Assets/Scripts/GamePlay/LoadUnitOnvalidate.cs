using UnityEngine;
using System.Collections;

public class LoadUnitOnvalidate : MonoBehaviour
{
    public static LoadUnitOnvalidate instance;
    public Unit[] unitList;
    public Transform unitContainer;
    public StageManager stageManager;
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
            unitList = unitContainer.GetComponentsInChildren<Unit>();
            foreach (Unit unit in unitList) unit.gameObject.SetActive(false);
            if (stageManager != null)
            {
                stageManager.LoadUnit(unitList);
            }
        }
    }
}
