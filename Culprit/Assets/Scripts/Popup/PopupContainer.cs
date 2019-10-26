using UnityEngine;
using System.Collections;

public class PopupContainer : MonoBehaviour
{
    public static PopupContainer instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public IncorrectPopup incorrectPopupPrefab;
    public CorrectPopup correctPopupPrefab;

    public void GetIncorrectPopup()
    {
        GameObject obj = Instantiate(incorrectPopupPrefab.gameObject);
    }
    public void GetCorrectPopupPrefab()
    {
        GameObject obj = Instantiate(correctPopupPrefab.gameObject);
    }
}
