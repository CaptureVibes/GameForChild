using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpToPosition : MonoBehaviour
{
    // 目标位置
    public Vector3 targetPosition;

    // 移动的速度
    public float speed = 1.0f;

    void Update()
    {
        MoveToPosition(targetPosition, speed);
    }

    // 向上移动到特定位置的函数
    void MoveToPosition(Vector3 position, float speed)
    {
        // 获取当前物体的位置
        Vector3 currentPosition = transform.position;

        // 计算物体需要移动的距离
        float distance = Vector3.Distance(currentPosition, position);

        if (distance > 0.1f)
        {
            // 计算物体需要移动的方向
            Vector3 direction = (position - currentPosition).normalized;

            // 计算物体每一帧需要移动的距离
            float step = speed * Time.deltaTime;

            // 计算物体的新位置
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, position, step);

            // 更新物体的位置
            transform.position = newPosition;
        }
        else
        {
            // 到达目标位置后，禁用脚本的 Update 函数
            enabled = false;
        }
    }
}
