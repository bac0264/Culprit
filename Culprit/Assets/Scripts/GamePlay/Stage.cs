using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GamePlay;
using EnhancedUI.EnhancedScroller;
using EnhancedScrollerDemos.CellEvents;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Scripts.Interface;

public class Stage : CellView, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;
    public event Action<Stage> OnRightClickStageEvent;


    public UnitStage[] _unitList;

    public Image stageImage;
    public Text stageText;

    public int index;
    private void Start()
    {
        foreach (UnitStage unit in _unitList)
        {
            unit.OnRightClickEvent += OnRightClickEvent;
        }

    }
    public UnitStage GetUnitStage(int indexUnitStage)
    {
        if ((indexUnitStage) < _unitList.Length) return _unitList[indexUnitStage];
        return null;
    }
    public UnitStage GetNextUnitStage(int indexUnitStage)
    {
        if ((indexUnitStage + 1) < _unitList.Length)
        {
            UnitStage unitStage = _unitList[indexUnitStage + 1];
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
        if (unitstage != null && unitstage.unit != null)
        {
            // HideAll(unitstage);
            unitstage.ShowStage();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickEvent != null)
            {
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
            unit.ActiveUnitStage();
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

    public void LoadUnit(Unit[] units)
    {
        int i = 0;
        for (; i < units.Length && i < _unitList.Length; i++)
        {
            _unitList[i].LoadUnit(units[i]);
        }
        for (; i < _unitList.Length; i++)
        {
            _unitList[i].gameObject.SetActive(false);
        }
    }
    // Onvalidate
    #region
    private void OnValidate()
    {
        if (_unitList.Length == 0)
        {
            _unitList = GetComponentsInChildren<UnitStage>();
            for (int i = 0; i < _unitList.Length; i++)
            {
                _unitList[i]._index = i;
            }
        }
        if (stageText == null) stageText = transform.GetChild(1).GetComponent<Text>();
        if (stageImage == null) stageImage = GetComponent<Image>();
    }
    #endregion
}
