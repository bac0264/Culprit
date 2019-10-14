using UnityEngine;
using System.Collections;

public class PickUnitStageManager : MonoBehaviour
{
    [SerializeField] Stage stage;
    private void OnValidate()
    {
        if (stage == null) stage = GetComponent<Stage>();
    }
    private void Awake()
    {
        stage.OnRightClickEvent += PickUnitStage;
    }
    public void PickUnitStage(UnitStage unitStage)
    {
        stage.PickUnitStage(unitStage);
    }

}
