﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;
using EnhancedUI.EnhancedScroller;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Scripts.Interface;
using EnhancedScrollerDemos.SuperSimpleDemo;

public class Stage : CellView, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;
    public event Action<Stage> OnRightClickStageEvent;

    public UnitStage[] _unitList;

    public Image stageImage;
    public Text stageText;

    public int index;
    public int amountOfUnitStage;

    private void Awake()
    {
        if (unitStageContainer == null) unitStageContainer = GameObject.FindWithTag("UnitContainer").transform;
    }
    public override void SetData(Data data)
    {
        base.SetData(data);
        index = data.index;
        amountOfUnitStage = data.amountUnitStage;
    }
    public UnitStage GetUnitStage(int indexUnitStage)
    {
        if ((indexUnitStage) < _unitList.Length)
        {
            UnitStage unitStage = _unitList[indexUnitStage];
            unitStage.unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitStage._index);
            return unitStage;
        }
        return null;
    }
    public UnitStage GetNextUnitStage(int indexUnitStage)
    {
        if ((indexUnitStage + 1) < _unitList.Length)
        {
            UnitStage unitStage = _unitList[indexUnitStage + 1];
            unitStage.unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitStage._index);
            if (unitStage.unit != null) return unitStage;
            return null;
        }
        return null;
    }
    // Pick unit stage
    #region
    public void PickUnitStage(UnitStage unitstage)
    {
        Debug.Log("run");
        if (unitstage != null)
        {
            Unit unit = LoadUnitOnvalidate.instance.GetUnitFromResources(index, unitstage._index);
            if (unit != null)
            {
                unitstage.LoadUnit(unit);
                // HideAll(unitstage);
                unitstage.ShowStage();
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickStageEvent != null)
            {
                Debug.Log(this);
                OnRightClickStageEvent(this);
            }
        }
    }
    #endregion
    // Hide All unitStage didnt pick
    public void HideAll(UnitStage unitstage)
    {
        foreach (UnitStage unitStage in _unitList)
        {
            if (unitStage._index == unitstage._index)
            {
                unitStage.gameObject.SetActive(true);
            }
            else
            {
                unitStage.gameObject.SetActive(false);
            }
        }
    }
    public void ShowStage()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.SetupStageContainer(this);
        Hide();
        OpenAllUnitStage();
    }

    // Hide & Open Stage and unitStage
    #region

    // Hide Stage
    public void Hide()
    {
        stageText.gameObject.SetActive(false);
        stageImage.enabled = false;
    }
    // Open Stage
    public void Open()
    {
        stageText.gameObject.SetActive(true);
        stageImage.enabled = true;
    }

    public void OpenAllUnitStage()
    {
        foreach (UnitStage unit in _unitList)
        {
            unit.ActiveUnitStage(index);
        }
    }
    public void LoadImageForAllUnitStage()
    {
        foreach (UnitStage unit in _unitList)
        {
            unit.LoadImage(index);
        }
    }
    public void HideAllUnitStage()
    {
        foreach (UnitStage unit in _unitList)
        {
            unit.UnactiveUnitStage();
        }
        Open();
    }
    #endregion
    public void Back()
    {
        OpenAllUnitStage();
        Hide();
        StageManager.instance.SetupBtn(1);
    }

    // Onvalidate
    #region
    public Transform unitStageContainer;
    private void OnValidate()
    {
        if (stageText == null) stageText = transform.GetChild(1).GetComponent<Text>();
        if (stageImage == null) stageImage = GetComponent<Image>();
    }
    public void LoadUnit(Unit[] units)
    {
        //for(int g = 0; g < unitStageContainer.childCount; g++)
        //{
        //    unitStageContainer.GetChild(g).gameObject.SetActive(true);
        //}
        //_unitList = GetComponentsInChildren<UnitStage>();
        //int i = 0;
        //for (; i < units.Length && i < _unitList.Length; i++)
        //{
        //    _unitList[i].LoadUnitOnvalidate();
        //}
        //for (; i < _unitList.Length; i++)
        //{
        //    _unitList[i].unit = null;
        //    _unitList[i].gameObject.SetActive(false);
        //}
        //_unitList = GetComponentsInChildren<UnitStage>();
        //for (int k = 0; k < _unitList.Length; k++)
        //{
        //    _unitList[k]._index = k;
        //    _unitList[k].gameObject.SetActive(false);
        //}
    }
    #endregion
    public void LoadUnit()
    {
        for (int g = 0; g < unitStageContainer.childCount && g < amountOfUnitStage; g++)
        {
            unitStageContainer.GetChild(g).gameObject.SetActive(true);
        }
        _unitList = unitStageContainer.GetComponentsInChildren<UnitStage>();
        SetupEvent();
    }
    public void SetupEvent()
    {
        OnRightClickEvent += PickUnitStage;
        foreach (UnitStage unit in _unitList)
        {
            unit.OnRightClickEvent += OnRightClickEvent;
        }
    }

}
