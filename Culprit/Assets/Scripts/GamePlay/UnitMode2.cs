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
    public int MaxIndexScene;
    public int CurIndexScene;
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
        for(int i = 0; i < btnScenes.Count; i++)
        {
            if (i == 0) SetBtnSceneDisplay(i);
            int z = i;
            btnScenes[z].onClick.AddListener(delegate { SetBtnSceneDisplay(z); });
        }
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
        CurIndexScene = _index;
        if (_index <= MaxIndexScene)
        {
            for (int i = 0; i < btnScenes.Count; i++)
            {
                if (i == _index)
                {
                    btnScenes[i].transform.GetChild(0).gameObject.SetActive(true);
                    correctAnswerBtns[i].gameObject.SetActive(true);
                }
                else
                {
                    btnScenes[i].transform.GetChild(0).gameObject.SetActive(false);
                    correctAnswerBtns[i].gameObject.SetActive(false);
                }
                if (i < MaxIndexScene)
                {
                    btnScenes[i].GetComponent<Image>().color = passed;
                }
                else if (i == MaxIndexScene)
                {
                    btnScenes[i].GetComponent<Image>().color = current;
                }
                else
                {
                    btnScenes[i].GetComponent<Image>().color = defaultColor;
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
        if (MaxIndexScene > correctAnswerBtns.Count - 1)
        {
            MaxIndexScene = correctAnswerBtns.Count - 1;
            btnScenes[MaxIndexScene].GetComponent<Image>().color = passed;
            checks[MaxIndexScene] = true;
            isWin = true;
            return;
        }
        else if (MaxIndexScene <= 0)
        {
            return;
        }
        else
        {
            checks[MaxIndexScene - 1] = true;
            checks[MaxIndexScene] = false;
            btnScenes[MaxIndexScene - 1].GetComponent<Image>().color = passed;
            btnScenes[MaxIndexScene - 1].transform.GetChild(0).gameObject.SetActive(false);
            btnScenes[MaxIndexScene].GetComponent<Image>().color = current;
            btnScenes[MaxIndexScene].transform.GetChild(0).gameObject.SetActive(true);
            correctAnswerBtns[MaxIndexScene - 1].gameObject.SetActive(false);
            correctAnswerBtns[MaxIndexScene].gameObject.SetActive(true);
        }
    }
    public override void Next()
    {
        if (CurIndexScene < MaxIndexScene)
        {
            CurIndexScene++;
            SetBtnSceneDisplay(CurIndexScene);
        }
        else
        {
            MaxIndexScene++;
            CurIndexScene = MaxIndexScene;
            OpenScene();
        }
    }
    public override void IsWin()
    {
        if (isWin)
        {
            int curIndexUnit = SaveLoadStageData.LoadDataStage(indexStage);
            if (curIndexUnit <= indexUnit)
            {
                SaveLoadStageData.SaveDataStage(indexStage, indexUnit + 1);
                if (ButtonStageManager.instance != null && StageManager.instance != null)
                {
                    UnitStage unitStage = ButtonStageManager.instance.unitStage;
                    ButtonStageManager.instance.stage.LoadImageForAllUnitStage();
                    StageManager.instance.NextLevel(unitStage);
                }
            }
        }
    }
    public override void Try()
    {
    }
    //public void 
}
