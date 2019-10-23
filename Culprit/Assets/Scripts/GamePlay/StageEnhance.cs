using UnityEngine;
using System.Collections;
using EnhancedScrollerDemos.SuperSimpleDemo;
using EnhancedUI;

public class StageEnhance : SimpleDemo
{
    public static StageEnhance instance;
    private void Awake()
    {
        _data = new SmallList<Data>();
        if (instance == null) instance = this;
    }
    public override void Start()
    {
        base.Start();
    }
    public override void LoadLargeData()
    {
        int amount = LoadUnitOnvalidate.instance.GetAmountStage();
        //   amount = 100;
        // set up some simple data
        for (var i = 0; i < amount; i++)
        {
            int _amountUnitStage = LoadUnitOnvalidate.instance.GetAmountUnitStage(i);
            _data.Add(new DataStage() { indexStage = i, amountUnitStage = _amountUnitStage });
        }
        // tell the scroller to reload now that we have the data
        scroller.ReloadData();
        StageManager.instance.SetupEvent();
    }
}
