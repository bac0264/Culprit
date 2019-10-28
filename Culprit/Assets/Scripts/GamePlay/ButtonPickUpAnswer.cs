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
        if (unitstage.unit != null && unitstage.unit is UnitMode1) {
            UnitMode1 unit = unitstage.unit as UnitMode1;
            int amount = unit.btnContainer.childCount;
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
                        Vector3 pos = unit.btnContainer.GetChild(i).transform.localPosition;
                        btn.transform.DOMove(pos, 0);
                        int result = unit.GetResult(i);
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
        if (unitStage != null && unitStage.unit != null && unitStage.unit is UnitMode1)
        {
            UnitMode1 unit = unitStage.unit as UnitMode1;
            if (unit.IsWin(result))
            {
                Debug.Log("run");
            }
        }
        UnactiveBtn();
    }
    public void ActivePickupBtn()
    {
        foreach(Button btn in btns)
        {
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
