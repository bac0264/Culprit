using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform target;
    public bool TargetReady;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //public void Update()
    //{
    //    if (TargetReady)
    //    {
    //        Vector3 temp = target.localPosition;
    //        temp.x -= 5;
    //        temp.y += 20;
    //        temp.z = Camera.main.transform.position.z;
    //        transform.DOMove(temp, 0.1f);
    //    }
        
    //}
    public void GetTarget(Transform target)
    {
        this.target = target;
        if(target != null)
        {
            TargetReady = true;
            Vector3 temp = transform.position;
            temp.x = target.transform.localPosition.x;
            temp.y = target.transform.localPosition.y;
            transform.position = temp;
        }
    }
}
