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
    public int validate = 0;
    public bool isWin;
    private void OnValidate()
    {
        if (ani == null) ani = GetComponent<Animator>();
        if (validate == 0)
        {
            validate = 1;
            string[] _s = gameObject.name.Split(' ');
            Debug.Log(_s[0]);
            Debug.Log(_s[1]);
            indexStage = Int32.Parse(_s[0]);
            indexUnit = Int32.Parse(_s[1]);
            //gameObject.SetActive(false);
        }
        if (AskBtns.Count == 0)
        {            
            for(int i = 0; i < btnContainer.childCount; i++)
            {
                AskBtns.Add(btnContainer.GetChild(i).GetComponent<Transform>());
            }
        }
    }

    public void Win()
    {
        ani.Play("result_lose");
    }

    public void Lose()
    {
        ani.Play("result_win");
    }
    public bool IsWin(int index)
    {
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i] == index)
            {
                Win();
                isWin = true;
                return true;
            }
        }
        isWin = false;
        Lose();
        return false;
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
            ButtonStageManager.instance.ActivePickupBtn();
    }
    public void ShowPopup()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.ShowPopup(this);
    }
    #endregion
}
