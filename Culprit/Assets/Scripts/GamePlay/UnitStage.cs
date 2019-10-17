using Assets.Scripts.GamePlay;
using Assets.Scripts.Interface;
using EnhancedScrollerDemos.CellEvents;
using EnhancedUI.EnhancedScroller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitStage : CellView, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;
    private const int Passed = 0;
    private const int Next = 1;
    private const int Default = 2;
    public int _index;
    public bool _isPass;
    public bool _isOpen;


    public Unit unit;

    public Text level;
    public Image unitImage;
    public Sprite[] sprites;
    // not change
    #region
    private void OnValidate()
    {
        //if (unit == null)
        //{
        //    unit = GetComponentInChildren<Unit>();
        //    unit.gameObject.SetActive(false);
        //}
        if (unitImage == null) unitImage = GetComponent<Image>();
        if (level == null) level = GetComponentInChildren<Text>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }
    #endregion
    public void ShowStage()
    {
        Open();
        //  ShowStage();
        SetUpCamera();
    }
    // Open & Hide unit
    #region

    // Open unit
    public void Hide()
    {
        if (unit != null)
        {
            unit.gameObject.SetActive(false);
        }
    }
    // Hide unit
    public void Open()
    {
        if (unit != null)
        {
            unit.gameObject.SetActive(true);
        }
    }
    public void UnactiveUnitStage()
    {
        gameObject.SetActive(false);
    }
    public void ActiveUnitStage()
    {
        gameObject.SetActive(true);
        Hide();
    }
    #endregion
    public void LoadUnit(Unit unit)
    {
        this.unit = unit;
        level.text = (_index + 1).ToString();
        unit.gameObject.SetActive(false);
    }

    public void LoadUnitOnvalidate()
    {
        this.gameObject.SetActive(true);
    }
    public void SetUpCamera()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.TurnOn_Subcam(this);
    }
}
