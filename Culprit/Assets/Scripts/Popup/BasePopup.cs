using UnityEngine;
using System.Collections;

public class BasePopup : MonoBehaviour
{

    public virtual void ShowPopup()
    {
        gameObject.SetActive(true);
    }
    public virtual void HidePopup()
    {
        gameObject.SetActive(false);
    }
}
