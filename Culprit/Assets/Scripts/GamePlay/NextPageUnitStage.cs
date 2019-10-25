using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class NextPageUnitStage : MonoBehaviour
{
    public List<Transform> transformList;
    public bool StartNext;
    public int cur;
    private void OnValidate()
    {
        
    }
    public void Right()
    {
        transformList[cur].DOMove(transformList[cur + 1].position, 0.4f);
    }
    public void Left()
    {
        transformList[cur].DOMove(transformList[cur - 1].position, 0.4f);
    }

}
