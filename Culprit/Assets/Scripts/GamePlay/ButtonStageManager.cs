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
        TurnOffPopup();
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

    public void Try()
    {
        TurnOffPopup();
        if (unitStage.unit != null)
        {
            unitStage.unit.Try();
        }
    }
    public void Next()
    {
        TurnOffPopup();
        if (StageManager.instance != null)
            StageManager.instance.NextLevel(unitStage);
    }
    #endregion
    // Popup
    #region
    public void ShowPopup(Unit unit)
    {
        if (unit.isWin)
        {
            TurnOnWinPopup();
        }
        else
        {
            TurnOnLosePopup();
        }
    }
    public void TurnOffPopup()
    {
        if (LosePopup.instance != null && WinPopup.instance != null)
        {
            LosePopup.instance.HidePopup();
            WinPopup.instance.HidePopup();
        }
    }
    public void TurnOnPopup()
    {
        if (LosePopup.instance != null && WinPopup.instance != null)
        {
            LosePopup.instance.ShowPopup();
            WinPopup.instance.ShowPopup();
        }
    }
    public void TurnOnWinPopup()
    {
        if (LosePopup.instance != null && WinPopup.instance != null)
        {
            LosePopup.instance.HidePopup();
            WinPopup.instance.ShowPopup();
        }
    }
    public void TurnOnLosePopup()
    {
        if (LosePopup.instance != null && WinPopup.instance != null)
        {
            LosePopup.instance.ShowPopup();
            WinPopup.instance.HidePopup();
        }
    }
    #endregion
}
