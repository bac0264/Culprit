using UnityEngine;
using System.Collections;

public class PickStageManager : MonoBehaviour
{
    [SerializeField] StageManager stageManager;

    private void OnValidate()
    {
        if (stageManager == null) stageManager = GetComponent<StageManager>();
    }
    private void Awake()
    {
        stageManager.OnRightClickStageEvent += PickStage;
    }

    public void PickStage(Stage stage)
    {
        stageManager.PickStage(stage);
    }
}
