using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStageManager : MonoBehaviour
{
    public static ButtonStageManager instance;
    public ButtonPickUpAnswer btnPickup;
    public Camera mainCam;
    public Camera subCamm_1;
    public Stage stage;
    public UnitStage unitStage;
    public GameObject Mode2Cotnainer;
    private void Awake()
    {
        if (instance == null) instance = this;

    }
    private void OnValidate()
    {
        if (btnPickup == null) btnPickup = FindObjectOfType<ButtonPickUpAnswer>();
    }
    public void TurnOn_MainCam()
    {
        TurnOffAllPopup();
        mainCam.gameObject.SetActive(true);
        subCamm_1.gameObject.SetActive(false);
        if (unitStage != null)
        {
            unitStage.Hide();
            //unitStage.unit = null;
            //unitStage. = null;
        }
        UnactiveBtn();
    }
    public void TurnOn_Subcam(UnitStage unit)
    {
        this.unitStage = unit;
        if (unit.unit is UnitMode1)
        {
            Mode2Cotnainer.SetActive(false);
        }
        else
        {
            Mode2Cotnainer.SetActive(true);
        }
        subCamm_1.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        btnPickup.AddBtns(unitStage);
    }
    public void SetupStageContainer(Stage stage)
    {
        this.stage = stage;
    }
    // Active and Unactive BtnAsk
    #region

    public void ActivePickupBtn()
    {
        btnPickup.ActivePickupBtn();

    }
    public void UnactiveBtn()
    {
        btnPickup.UnactiveBtn();
    }
    #endregion
    // Button Next Try of Popup
    #region
    public void TurnOffAllPopup()
    {
        if (WinPopup.instance != null) WinPopup.instance.HidePopup();
        if (LosePopup.instance != null) LosePopup.instance.HidePopup();
        if (CorrectPopup.instance != null) CorrectPopup.instance.HidePopup();
        if (IncorrectPopup.instance != null) IncorrectPopup.instance.HidePopup();
    }

    #endregion
    // Popup
    #region
    public void ShowPopup(Unit unit)
    {
        if (unit.isWin)
        {
            if (WinPopup.instance == null) PopupContainer.instance.GetWinPopup();
            if (WinPopup.instance != null)
            {
                WinPopup.instance.ShowPopup();
            }
        }
        else
        {
            if (LosePopup.instance == null) PopupContainer.instance.GetLosePopup();
            if (LosePopup.instance != null)
            {
                LosePopup.instance.ShowPopup();
            }
        }
    }
    #endregion
}
