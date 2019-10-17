using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        if (!PlayerPrefs.HasKey(KeySave.IS_THE_FIRST_TIME))
        {

        }
        else
        {

        }
    }
}
