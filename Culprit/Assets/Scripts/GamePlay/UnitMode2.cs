using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnitMode2 : Unit
{
    public List<Button> correctAnswerBtns;
    public List<Button> btnScenes;
    public Transform containerCorrectAnswersBtn;
    public Transform BtnContainer;
    public bool[] checks;
    public int indexScene;
    public Color defaultColor = Color.white;
    public Color passed = Color.red;
    public Color current = Color.yellow;
    public override void OnValidate()
    {
        base.OnValidate();
        if (correctAnswerBtns.Count == 0)
        {
            for (int i = 0; i < containerCorrectAnswersBtn.childCount; i++)
            {
                correctAnswerBtns.Add(containerCorrectAnswersBtn.GetChild(i).GetComponent<Button>());
            }
        }
        if (btnScenes.Count == 0)
        {
            for (int i = 0; i < BtnContainer.childCount; i++)
            {
                btnScenes.Add(BtnContainer.GetChild(i).GetComponent<Button>());
            }
        }
        if (checks.Length == 0)
        {
            checks = new bool[4];
        }
    }
    private void Awake()
    {
        SetBtnSceneDisplay(0);
        btnScenes[0].onClick.AddListener(delegate { SetBtnSceneDisplay(0); });
        btnScenes[1].onClick.AddListener(delegate { SetBtnSceneDisplay(1); });
        btnScenes[2].onClick.AddListener(delegate { SetBtnSceneDisplay(2); });
        btnScenes[3].onClick.AddListener(delegate { SetBtnSceneDisplay(3); });
        for (int i = 0; i < correctAnswerBtns.Count; i++)
        {
            // correctAnswerBtns[i].onClick.RemoveAllListeners();
            correctAnswerBtns[i].onClick.AddListener(delegate { SetCorrectAnswerButton(); });
        }
    }
    public void SetCorrectAnswerButton()
    {
        Correct();
    }
    public void SetBtnSceneDisplay(int _index)
    {
        if (_index <= indexScene)
        {
            for (int i = 0; i < btnScenes.Count; i++)
            {
                if (i <= indexScene)
                {
                    if (i == _index)
                    {
                        btnScenes[i].GetComponent<Image>().color = current;
                        correctAnswerBtns[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        btnScenes[i].GetComponent<Image>().color = passed;
                        correctAnswerBtns[i].gameObject.SetActive(false);
                    }
                }
                else
                {
                    btnScenes[i].GetComponent<Image>().color = defaultColor;
                    correctAnswerBtns[i].gameObject.SetActive(false);
                }
            }
        }
    }
    // Show popup if incorrect
    public void Incorrect()
    {
        if (IncorrectPopup.instance == null) PopupContainer.instance.GetIncorrectPopup();
        if (IncorrectPopup.instance != null)
        {
            IncorrectPopup.instance.ShowPopup();
        }
    }
    public void Correct()
    {
        if (CorrectPopup.instance == null) PopupContainer.instance.GetCorrectPopupPrefab();
        if (CorrectPopup.instance != null)
        {
            CorrectPopup.instance.ShowPopup();
            CorrectPopup.instance.container = this;
        }
    }
    public void OpenScene()
    {
        if (indexScene > correctAnswerBtns.Count - 1)
        {
            indexScene = correctAnswerBtns.Count - 1;
            btnScenes[indexScene].GetComponent<Image>().color = passed;
            checks[indexScene] = true;
            isWin = true;
            return;
        }
        else if (indexScene <= 0)
        {
            return;
        }
        else
        {
            checks[indexScene - 1] = true;
            checks[indexScene] = false;
            btnScenes[indexScene - 1].GetComponent<Image>().color = passed;
            btnScenes[indexScene].GetComponent<Image>().color = current;
            correctAnswerBtns[indexScene - 1].gameObject.SetActive(false);
            correctAnswerBtns[indexScene].gameObject.SetActive(true);
        }
    }
    public override void Next()
    {
        indexScene++;
        OpenScene();
    }
    public override void IsWin()
    {
        if (isWin)
        {
            int curIndexUnit = SaveLoadStageData.LoadDataStage(indexStage);
            Debug.Log("curIden: " + curIndexUnit);
            if (curIndexUnit <= indexUnit)
            {
                Debug.Log("run");
                SaveLoadStageData.SaveDataStage(indexStage, indexUnit + 1);
                UnitStage unitStage = StageManager.instance.GetUnitStage(indexStage, indexUnit);
                StageManager.instance.NextLevel(unitStage);
                StageManager.instance.GetStage(indexStage).LoadImageForAllUnitStage();
            }
        }
    }
    public override void Try()
    {
    }
    //public void 
}
