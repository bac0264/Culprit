using UnityEngine;
using System.Collections;
using System;

public class DailyManager : MonoBehaviour
{
    public static DailyManager instance;
    public DailyPanel dailyPanel;
    public DailyReward dailyReward;
  //  public GameObject progress;
  //  public DailyRewardDataCSV data;
    public int indexReward;
    public int IndexReward
    {
        set
        {
            indexReward = value;
            PlayerPrefs.SetInt(KeySave.INDEX_FREE_REWARD, indexReward);
        }
        get
        {
            return indexReward;
        }
    }
    private void OnValidate()
    {
        if (dailyPanel == null) dailyPanel = GetComponentInChildren<DailyPanel>();
        if (dailyReward == null) dailyReward = GetComponentInChildren<DailyReward>();
    }
    private void Awake()
    {
        if (instance == null) instance = this;
        dailyPanel.OnRightClickEvent += RecieveReward;
        dailyPanel.LoadData();
    }
    private void Start()
    {
        Setup();
        gameObject.SetActive(false);
    }
    public void Setup()
    {
        IndexReward = PlayerPrefs.GetInt(KeySave.INDEX_FREE_REWARD, 0);
        SetupReward();
    }
    public void RecieveReward(DailySlot slot)
    {
        if (slot.ID <= IndexReward && !slot.IsRecieve && slot.IsOpen)
        {
            slot.IsRecieve = true;
            if (IndexReward == (dailyPanel.slots.Length - 1))
            {
                if (dailyPanel.IsRecieveAll())
                {
                    IndexReward = -1;
                    dailyReward._checktime();
                }
            }
            dailyPanel.SaveData();
        }
        else
        {

        }
    }
    public bool NextReward()
    {
        if (IndexReward > (dailyPanel.slots.Length - 1))
        {
            return false;
        }
        else if (IndexReward == (dailyPanel.slots.Length - 1))
        {
            DailySlot next = dailyPanel.getNextSlot(IndexReward);
            if (next != null)
            {
                next.IsOpen = true;
              //  progress.SetActive(false);
            }
            return false;
        }
        else
        {
            DailySlot next = dailyPanel.getNextSlot(IndexReward);
            if (next != null)
            {
                next.IsOpen = true;
                IndexReward++;
                return true;
            }
            return false;
        }
    }
    public void WaitForTimeToOpenReward()
    {
        if (IndexReward == (dailyPanel.slots.Length - 1))
        {

        }
        else if (IndexReward >= 0 && IndexReward < (dailyPanel.slots.Length - 1))
        {
            dailyPanel.getNextSlot(indexReward).IsOpen = false;
        }
        else
        {

        }
    }
    public void SetupReward()
    {
        if (IndexReward <= (dailyPanel.slots.Length - 1))
        {
            if (PlayerPrefs.GetString("_timer") == "")
            {
                Debug.Log("==> Enableing button");

                dailyReward.SetupTime();
                NextReward();
                dailyReward.rewardClicked();
            }
            else
            {
                dailyReward._checktime();
                //SetpositionProgress();
            }
        }
    }
    //public void SetpositionProgress(DailySlot dailyPanel)
    //{
    //    progress.transform.position = dailyPanel.transform.position;
    //    progress.transform.SetParent(dailyPanel.transform);
    //    progress.SetActive(true);
    //}
    //public void SetpositionProgress()
    //{
    //    dailyPanel.getNextSlot(indexReward).IsOpen = false;
    //    progress.transform.position = dailyPanel.getNextSlot(IndexReward).transform.position;
    //    progress.transform.SetParent(dailyPanel.getNextSlot(IndexReward).transform);
    //    progress.SetActive(true);
    //}
}
