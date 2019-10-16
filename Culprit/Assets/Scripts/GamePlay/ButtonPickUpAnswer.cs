using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
public class ButtonPickUpAnswer : MonoBehaviour
{
    public static ButtonPickUpAnswer Instance;
    public List<Button> btns;
    public ObjectPooling objPooling;

    private void OnValidate()
    {
        if (objPooling == null) objPooling = GetComponent<ObjectPooling>();
    }
    public void SetupInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void AddBtns(UnitStage unitstage)
    {
        if (unitstage.unit != null) {
            int amount = unitstage.unit.btnContainer.childCount;
            Debug.Log("amount: " + amount);
            if (amount > 0)
            {
                btns.Clear();
                for (int i = 0; i < amount; i++)
                {
                    GameObject obj = objPooling.getObjectPooling();
                    Button btn = obj.GetComponent<Button>();
                    if (btn != null)
                    {
                        btn.onClick.RemoveAllListeners();
                        Vector3 pos = unitstage.unit.btnContainer.GetChild(i).transform.localPosition;
                        btn.transform.DOMove(pos, 0);
                        int result = unitstage.unit.GetResult(i);
                        Debug.Log(result);
                        btn.onClick.AddListener(delegate { SetupBtn(unitstage, result); });
                        btn.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                        btns.Add(btn);
                    }
                }
            }
        }
        UnactiveBtn();
    }
    void SetupBtn(UnitStage unitStage, int result)
    {
        PlayerPrefs.SetInt("PickUpCulprit", result);
        Debug.Log("index: " + result);
        if (unitStage != null && unitStage.unit != null)
        {
            if (unitStage.unit.IsWin(PlayerPrefs.GetInt("PickUpCulprit")))
            {
                Debug.Log("index: " + PlayerPrefs.GetInt("PickUpCulprit"));
            }
        }
        UnactiveBtn();
    }
    public void ActivePickupBtn()
    {
        foreach(Button btn in btns)
        {
            Debug.Log("run");
            btn.gameObject.SetActive(true);
        }

    }
    public void UnactiveBtn()
    {
        foreach (Button btn in btns)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
