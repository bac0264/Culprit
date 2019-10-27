using UnityEngine;
using System.Collections;
using Spine.Unity;
using System.Collections.Generic;
using System;

public class Unit : MonoBehaviour
{
    public int indexStage;
    public int indexUnit;
    public bool isWin;
    public virtual void OnValidate()
    {
        string[] _s = gameObject.name.Split('_');
        indexStage = Int32.Parse(_s[0]);
        indexUnit = Int32.Parse(_s[1]);
    }
    //public Transform[] GetAskBtns()
    //{
    //    AskBtns = btnContainer.GetComponentsInChildren<Transform>();
    //    return AskBtns;
    //}
    // Set Event in animation
    public virtual void Try() { }
    public virtual void Next() { }
    #region
    public virtual void IsWin() { }
    public virtual void ShowPopup()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.ShowPopup(this);
    }
    #endregion
}
