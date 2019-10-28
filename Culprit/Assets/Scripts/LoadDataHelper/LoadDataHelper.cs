using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{

    public TextAsset QuestionData;
    public QuestionDataContainer dataList;
 
    public void LoadData()
    {
        var dataLoaded = CSVReader.Read(QuestionData);
        dataList.LoadQuestionData(dataLoaded);   
    }

}