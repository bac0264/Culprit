using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ClickedStages()
    {
        SceneManager.LoadScene("Stages");
    }
    public void ClickDaily()
    {
        DailyManager.instance.gameObject.SetActive(true);
    }
    public void ExitDaily()
    {
        DailyManager.instance.gameObject.SetActive(false);
    }
}
