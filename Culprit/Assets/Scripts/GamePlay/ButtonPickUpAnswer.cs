using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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
    public void AddBtn(int amount)
    {
        if (amount > 0)
        {
            btns.Clear();
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = objPooling.getObjectPooling();
                Button btn = obj.GetComponent<Button>();
                if (btn != null) btns.Add(btn);
            }
        }
    }
}
