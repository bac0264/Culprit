using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoadStageData
{
    public static void SaveDataStage(int indexStage, int indexUnitStage)
    {
        //Debug.Log("string save: " + GetIndexUnitStage(indexStage));
        //Debug.Log("value save: " + PlayerPrefs.GetInt(GetIndexUnitStage(indexStage)));
        PlayerPrefs.SetInt(GetIndexUnitStage(indexStage), indexUnitStage);
    }
    public static string GetIndexUnitStage(int index)
    {
        return (KeySave.STAGE_DATA + index.ToString());
    }
    public static int LoadDataStage(int indexStage)
    {
        //Debug.Log("string: " + GetIndexUnitStage(indexStage));
        //Debug.Log("value: " + PlayerPrefs.GetInt(GetIndexUnitStage(indexStage)));
        return PlayerPrefs.GetInt(GetIndexUnitStage(indexStage));
    }

}
