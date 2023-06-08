using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectDistance : MonoBehaviour
{
    // 要检测距离的另一个物体
    public GameObject otherObject;
    public GameObject theObject;

    // 合适的距离范围
    public float distanceThreshold;

    void Update()
    {
        // 计算这个物体和 otherObject 之间的距离
        float xDistance = Mathf.Abs(otherObject.transform.position.x - theObject.transform.position.x);

        // 如果距离在合适的范围内，执行一些操作
        if (xDistance < distanceThreshold)
        {
            // 执行一些需要执行的操作
            Debug.Log("Distance within threshold");
        }
    }
    
}