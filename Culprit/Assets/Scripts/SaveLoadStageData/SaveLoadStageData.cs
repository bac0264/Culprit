using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveLoadStageData
{
    public static void SaveDataStage()
    {
        List<string> s = new List<string>();
        // i is Stage
        for (int i = 0; i < KeySave.STAGE_AMOUNT; i++)
        {
            s.Add(i + "," + PlayerPrefs.GetFloat(GetIndexUnitStage(i)));
        }
    }
    public static string GetIndexUnitStage(int index)
    {
        return (KeySave.STAGE_DATA + index.ToString());
    }
    public static void LoadDataStage()
    {
        string[] s = PlayerPrefsX.GetStringArray(KeySave.STAGE_DATA);

        for (int j = 0; j < s.Length; j++)
        {
            string[] ss = s[j].Split(',');
            for(int i = 0; i < ss.Length; i++)
            {

            }
        }
    }
}
