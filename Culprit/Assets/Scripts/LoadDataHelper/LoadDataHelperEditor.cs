using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoadDataHelper))]
[CanEditMultipleObjects]
public class LoadDataHelperEditor : Editor
{

    public override void OnInspectorGUI()
    {
        LoadDataHelper myscript = (LoadDataHelper)target;

        if (GUILayout.Button("Load Data"))
        {
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataList);
        }

        base.OnInspectorGUI();
    }

}
