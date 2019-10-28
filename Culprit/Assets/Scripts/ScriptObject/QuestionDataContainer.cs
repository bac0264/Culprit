using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestionData", menuName = "QuestionData/QuestionData", order = 1)]
public class QuestionDataContainer : ScriptableObject
{
    public List<QuestionData> questionList;

    public void LoadQuestionData(List<Dictionary<string, string>> dataCSV)
    {
        questionList = new List<QuestionData>();
        for (int i = 0; i < dataCSV.Count; i++)
        {
            QuestionData dataEnemy = new QuestionData(dataCSV[i]);
            questionList.Add(dataEnemy);
        }
    }

}
[System.Serializable]
public class QuestionData
{
    public int MODE;
    public int LEVEL;
    private string QUES_1;
    private string QUES_2;
    private string QUES_3;
    private string QUES_4;
    public List<string> listQues;
    public QuestionData(Dictionary<string, string> data)
    {
        listQues = new List<string>();
        MODE = int.Parse(data["MODE"]);
        LEVEL = int.Parse(data["LEVEL"]);
        QUES_1 = data["QUES_1"];
        listQues.Add(QUES_1);
        QUES_2 = data["QUES_2"];
        listQues.Add(QUES_2);
        QUES_3 = data["QUES_3"];
        listQues.Add(QUES_3);
        QUES_4 = data["QUES_4"];
        listQues.Add(QUES_4);
    }
}
