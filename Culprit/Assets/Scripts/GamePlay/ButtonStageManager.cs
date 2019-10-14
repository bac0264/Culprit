using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStageManager : MonoBehaviour
{
    public static ButtonStageManager instance;
    public Camera mainCam;
    public Camera subCamm_1;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject _winPopup;
    public GameObject _losePopup;
    public UnitStage unitStage;
    private void Awake()
    {
        if (instance == null) instance = this;
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
    }
    public void Pickup_1()
    {
        PlayerPrefs.SetInt("PickUpCulprit", 0);
        if (unitStage != null && unitStage.unit != null)
        {
            if (unitStage.unit.IsWin(PlayerPrefs.GetInt("PickUpCulprit")))
            {

            }
        }
        UnactiveBtn();
    }
    public void Pickup_2()
    {
        PlayerPrefs.SetInt("PickUpCulprit", 1);
        if (unitStage != null && unitStage.unit != null)
        {
            if (unitStage.unit.IsWin(PlayerPrefs.GetInt("PickUpCulprit")))
            {
            }
        }
        UnactiveBtn();
    }
    public void ActivePickupBtn()
    {
        btn1.SetActive(true);
        btn2.SetActive(true);

    }
    public void UnactiveBtn()
    {
        btn1.SetActive(false);
        btn2.SetActive(false);
    }

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
    public void Try()
    {
        TurnOffPopup();
        if (unitStage.unit != null) unitStage.unit.ani.Rebind();
    }
    public void Next()
    {
        TurnOffPopup();
        if (StageManager.instance != null)
            StageManager.instance.NextLevel(unitStage);
    }
    // Popup
    #region
    public void TurnOffPopup()
    {
        _losePopup.SetActive(false);
        _winPopup.SetActive(false);
    }
    public void TurnOnPopup()
    {
        _losePopup.SetActive(true);
        _winPopup.SetActive(true);
    }
    public void TurnOnWinPopup()
    {
        _losePopup.SetActive(false);
        _winPopup.SetActive(true);
    }
    public void TurnOnLosePopup()
    {
        _losePopup.SetActive(true);
        _winPopup.SetActive(false);
    }
    #endregion
}
