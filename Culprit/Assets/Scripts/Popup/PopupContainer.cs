using UnityEngine;
using System.Collections;

public class PopupContainer : MonoBehaviour
{
    public static PopupContainer instance;
    public Transform container;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public IncorrectPopup incorrectPopupPrefab;
    public CorrectPopup correctPopupPrefab;
    public LosePopup losePrefab;
    public WinPopup winPrefab;
    public QuestionPopup questionPopup;
    public void GetIncorrectPopup()
    {
        GameObject obj = Instantiate(incorrectPopupPrefab.gameObject, container);
    }
    public void GetCorrectPopupPrefab()
    {
        GameObject obj = Instantiate(correctPopupPrefab.gameObject, container);
    }
    public void GetWinPopup()
    {
        GameObject obj = Instantiate(winPrefab.gameObject, container);
    }
    public void GetLosePopup()
    {
        GameObject obj = Instantiate(losePrefab.gameObject, container);
    }
    public void GetQuestionPopup()
    {
        GameObject obj = Instantiate(questionPopup.gameObject, container);
    }

    //---------------------------------------
    public void SetupQuestionBtn()
    {
        if (QuestionPopup.instance == null) GetQuestionPopup();
        if (QuestionPopup.instance != null)
        {
            QuestionPopup.instance.ShowPopup();
        }
    }
}
