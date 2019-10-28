using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionPopup : BasePopup
{
    public static QuestionPopup instance;

    public QuestionDataContainer questData;

    public Text question;

    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void ShowPopup()
    {
        unitStage = ButtonStageManager.instance.unitStage;
        if(unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode2)
        {
            UnitMode2 unitMode2 = unitStage.unit as UnitMode2;
            question.text = GetQuestion(unitMode2.indexStage, unitMode2.indexUnit, unitMode2.CurIndexScene);
        }
        base.ShowPopup();
    }
    public string GetQuestion(int Stage, int UnitStage, int indexScene)
    {
        Debug.Log(Stage);
        Debug.Log(UnitStage);
        Debug.Log(questData.questionList.Count);
        for(int i = 0; i < questData.questionList.Count; i++)
        {
            if(questData.questionList[i].MODE == (Stage+1) && questData.questionList[i].LEVEL == (UnitStage + 1))
            {
                return questData.questionList[i].listQues[indexScene];
            }
        }
        return " ";
    }
}
