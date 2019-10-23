using UnityEngine;
using System.Collections;
using Spine.Unity;
using System.Collections.Generic;
using System;

public class Unit : MonoBehaviour
{
    public Animator ani;
    public Transform btnContainer;
    public List<Transform> AskBtns;
    public List<int> results = new List<int>();
    public int indexStage;
    public int indexUnit;
    public bool isWin;
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();

        string[] _s = gameObject.name.Split('_');
        indexStage = Int32.Parse(_s[0]);
        indexUnit = Int32.Parse(_s[1]);
        //gameObject.SetActive(false);

        if (AskBtns.Count == 0)
        {
            for (int i = 0; i < btnContainer.childCount; i++)
            {
                AskBtns.Add(btnContainer.GetChild(i).GetComponent<Transform>());
            }
        }
    }

    public void Lose()
    {
        ani.Play("result_lose");
    }

    public void Win()
    {
        ani.Play("result_win");
    }
    public bool IsWin(int index)
    {
        if (index == 1)
        {
            Win();
            isWin = true;
            return true;
        }
        isWin = false;
        Lose();
        return false;
    }
    public int GetResult(int btnIndex)
    {
        if (btnIndex < 0 || AskBtns.Count == 0 || btnIndex >= AskBtns.Count) return 0;
        return results[btnIndex];
    }
    //public Transform[] GetAskBtns()
    //{
    //    AskBtns = btnContainer.GetComponentsInChildren<Transform>();
    //    return AskBtns;
    //}
    // Set Event in animation
    #region
    public void ActiveBtn()
    {
        if (ButtonStageManager.instance != null)
        {
            ButtonStageManager.instance.ActivePickupBtn();
        }
    }
    public void ShowPopup()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.ShowPopup(this);
    }
    public void EventWin()
    {
        int curIndexUnit = SaveLoadStageData.LoadDataStage(indexStage);
        if (curIndexUnit <= indexUnit)
        {
            Debug.Log("run");
            SaveLoadStageData.SaveDataStage(indexStage, indexUnit + 1);
            ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
        }
    }
    #endregion
}
