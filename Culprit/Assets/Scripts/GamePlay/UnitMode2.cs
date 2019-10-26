using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitMode2 : Unit
{
    public List<Button> correctAnswerBtns;
    public Transform containerCorrectAnswersBtn;
    public bool[] checks;
    public int indexScene;
    public Color defaultColor = Color.white;
    public Color passed = Color.red;
    public Color current = Color.yellow;
    public override void OnValidate()
    {
        base.OnValidate();
        if (correctAnswerBtns.Count == 0)
        {
            Debug.Log(containerCorrectAnswersBtn.childCount);
            for (int i = 0; i < containerCorrectAnswersBtn.childCount; i++)
            {
                correctAnswerBtns.Add(containerCorrectAnswersBtn.GetChild(i).GetComponent<Button>());
            }
        }
        if (checks.Length == 0)
        {
            checks = new bool[4];
        }
    }
    public override void Try()
    {

    }
    public void Incorrect()
    {
        if (IncorrectPopup.instance == null) PopupContainer.instance.GetIncorrectPopup();
        if (IncorrectPopup.instance != null)
        {
            IncorrectPopup.instance.ShowPopup();
        }
    }
    public void Correct()
    {
        if (CorrectPopup.instance == null) PopupContainer.instance.GetCorrectPopupPrefab();
        if (CorrectPopup.instance != null)
        {
            CorrectPopup.instance.ShowPopup();
        }
    }
    //public void 
}
