using Assets.Scripts.GamePlay;
using Assets.Scripts.Interface;
using EnhancedScrollerDemos.SuperSimpleDemo;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitStage : MonoBehaviour, IShowStage, IPointerClickHandler, IHide, IOpen
{
    public event Action<UnitStage> OnRightClickEvent;

    private const int PASSED = 0;
    private const int CURRENT = 1;
    private const int HIDE = 2;
    private Color defaultColor = new Color(1, 1, 1, 1);
    private Color hide = new Color(1, 1, 1, 100f / 255f);

    public int _index;
    public bool _isPass;
    public bool _isOpen;

    public SpriteUnitStageSO unitSprite;
    public Unit unit;

    public Text level;
    public Image unitImage;
    public void SetData(Data data)
    {
        if (data is DataUnitStage)
        {
            DataUnitStage dataUnitStage = data as DataUnitStage;
            level.text = (dataUnitStage.indexUnitStage + 1).ToString();
            _index = dataUnitStage.indexUnitStage;
            LoadImage(dataUnitStage.indexStage);
        }
    }
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
    public void ActiveUnitStage(int indexStage)
    {
        gameObject.SetActive(true);
        Hide();
    }
    #endregion
    public void LoadImage(int indexStage)
    {
        int curUnitStage = SaveLoadStageData.LoadDataStage(indexStage);
        if (_index < curUnitStage)
        {
            enabled = true;
            level.color = defaultColor;
            unitImage.color = defaultColor;
            unitImage.sprite = unitSprite.GetSprite(PASSED);
        }
        else if (_index == curUnitStage)
        {
            enabled = true;
            level.color = defaultColor;
            unitImage.color = defaultColor;
            unitImage.sprite = unitSprite.GetSprite(CURRENT);
        }
        else
        {
            enabled = false;
            level.color = hide;
            unitImage.color = hide;
            unitImage.sprite = unitSprite.GetSprite(HIDE);
        }
    }
    public void LoadUnit(Unit unit)
    {
        this.unit = unit;
        unit.gameObject.SetActive(false);
    }
    public void SetUpCamera()
    {
        if (ButtonStageManager.instance != null)
            ButtonStageManager.instance.TurnOn_Subcam(this);
    }
    // Onvalidate
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
    public void LoadUnitOnvalidate()
    {
        level.text = (_index + 1).ToString();
        this.gameObject.SetActive(true);
    }
    #endregion
}
