using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // 定义新颜色
    public Color newColor = Color.red;

    void Start()
    {
        // 获取物体的 Renderer 组件
        Renderer renderer = GetComponent<Renderer>();

        // 获取物体的材质
        Material material = renderer.material;

        // 设置材质的颜色为新颜色
        material.color = newColor;
    }
}