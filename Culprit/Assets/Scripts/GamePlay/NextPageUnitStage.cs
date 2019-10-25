using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class NextPageUnitStage : MonoBehaviour
{
    public List<GameObject> Objs;
    public Vector3 distance = new Vector2(0, 0);
    public bool StartNext;
    public int cur;
    public Vector3 middleDistance;
    public Vector3 rightDistance;
    public Vector3 leftDistance;
    private void Awake()
    {
        distance = Objs[1].transform.position - Objs[0].transform.position;
        middleDistance = Objs[0].transform.position;
        rightDistance = Objs[1].transform.position;
        leftDistance = Objs[0].transform.position - distance;
    }
    public void Right()
    {
        DOTween.CompleteAll();
        if (StartNext)
        {
            if (cur >= Objs.Count - 1)
            {
                Objs[0].transform.DOMove(middleDistance, 0.2f);
                Objs[cur].transform.DOMove(leftDistance, 0.2f);
                cur = 0;
            }
            else
            {
                Objs[cur + 1].transform.DOMove(middleDistance, 0.2f);
                Objs[cur].transform.DOMove(leftDistance, 0.2f);
                cur++;
                if(cur == Objs.Count - 1)
                {
                    ResetAll();
                }
            }
        }
    }
    public int GetVisibleContainer()
    {
        int i = 0;
        foreach(GameObject obj in Objs)
        {
            if (obj.activeInHierarchy) i++;
        }
        if (i <= 1) StartNext = false;
        else StartNext = true;
        return i;
    }
    public void ResetAll()
    {
        for(int i = 0; i < Objs.Count - 1; i++)
        {
            Objs[i].transform.position = middleDistance + distance;
        }
    }
    //public void Left()
    //{
    //    Objs[cur + 1].transform.DOMove(Objs[cur].transform.position, 0.4f);
    //    Objs[cur].transform.DOMove(new Vector2(Objs[cur].transform.position.x - distance, Objs[cur].transform.position.y), 0.4f);
    //    cur++;
    //}

}
