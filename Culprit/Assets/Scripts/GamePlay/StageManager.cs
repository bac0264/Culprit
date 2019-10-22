﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;
using System;
using Assets.Scripts.Interface;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EnhancedScrollerDemos.SuperSimpleDemo;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public Stage[] _stageList;
    public event Action<Stage> OnRightClickStageEvent;
    public Button[] btns;
    private void Awake()
    {
        if (instance == null) instance = this;

    }
    public void NextLevel(UnitStage cur)
    {
        if (cur.unit.indexStage < _stageList.Length)
        {
            Stage curStage = _stageList[cur.unit.indexStage];
            UnitStage curUnitStage = curStage.GetNextUnitStage(cur.unit.indexUnit);
            // if unitstage belong to curStage -> show, else -> next stage
            if (curUnitStage != null)
            {
                cur.Hide();
                curUnitStage.ShowStage();
                return;
            }
            else
            {
                // if nextstage exist -> get the first element.
                if ((cur.unit.indexStage + 1) < _stageList.Length)
                {
                    Stage nextStage = _stageList[cur.unit.indexStage + 1];
                    curUnitStage = nextStage.GetUnitStage(0);
                    if (curUnitStage != null)
                    {
                        HideAll(nextStage);
                        nextStage.ShowStage();
                        cur.Hide();
                        curUnitStage.ShowStage();
                        return;
                    }
                    else
                    {
                        BackMenu();
                    }
                }
                return;
            }
        }
        return;
    }
    // Pickup, Open && Hide All Stage
    #region
    public void PickStage(Stage Stage)
    {
        Stage.LoadUnit();
        HideAll(Stage);
        Stage.ShowStage();
        SetupBtn(1);
    }
    // Hide all Stage except picked Stage
    public void HideAll(Stage Stage)
    {
        foreach (Stage stage in _stageList)
        {
            if (stage.index != Stage.index) stage.gameObject.SetActive(false);
            else stage.gameObject.SetActive(true);
        }
    }
    public void OpenAllStage()
    {
        foreach (Stage stage in _stageList)
        {
            stage.gameObject.SetActive(true);
            stage.HideAllUnitStage();
        }
    }
    #endregion
    public void Back()
    {
        OpenAllStage();
        btns[0].gameObject.SetActive(true);
        btns[1].gameObject.SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SetupBtn(int index)
    {
        for (int i = 0; i < btns.Length; i++)
        {
            if (i == index)
            {
                btns[i].gameObject.SetActive(true);
            }
            else
                btns[i].gameObject.SetActive(false);
        }
    }
    // Load Onvalidate
    #region
    public void LoadUnit(Unit[] unitList)
    {
        for (int g = 0; g < transform.childCount; g++)
        {
            transform.GetChild(g).gameObject.SetActive(true);
        }
        _stageList = GetComponentsInChildren<Stage>();
        List<List<Unit>> list = new List<List<Unit>>();
        int amount = LoadUnitOnvalidate.instance.GetAmountStage();
        bool check = false;
        for (int i = 0; i < amount; i++)
        {
            List<Unit> _list = new List<Unit>();
            for (int j = 0; j < unitList.Length; j++)
            {
                if (unitList[j].indexStage == i)
                {
                    check = true;
                    _list.Add(unitList[j]);
                }
            }
            if (check)
            {
                list.Add(_list);
                check = false;
            }
        }
        int k = 0;
        for (; k < _stageList.Length && k < list.Count; k++)
        {
            _stageList[k].LoadUnit(list[k].ToArray());
        }
        for (; k < _stageList.Length; k++)
        {
            _stageList[k].gameObject.SetActive(false);
        }
        _stageList = GetComponentsInChildren<Stage>();
    }
    public void SetupEvent()
    {
        LoadUnit(LoadUnitOnvalidate.instance.unitList);
        OnRightClickStageEvent += PickStage;
        foreach (Stage stage in _stageList)
        {
            stage.OnRightClickStageEvent += OnRightClickStageEvent;
        }
    }
    #endregion

}
