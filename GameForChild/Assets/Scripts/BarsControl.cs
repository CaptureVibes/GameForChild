using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarsControl : MonoBehaviour
{
    public FragAddition.Fraction myAddend;
    private float zPos;
    private GameObject clone;
    public bool ifClone = false;
    public bool isAtLine = false;
    private bool isInLine = false;
    public bool isAdded = false;

    public GameObject gapPos;
    bool issettle = false;

    

    private Bounds  LineBounds;
 

    public int myAddendDomi;


    private void Update()
    {

        BoxCollider2D collider =GameObject.Find("ButtomLine") .GetComponent<BoxCollider2D>();
        LineBounds = collider.bounds;
        if(isInLine)
        {
            if (!isAtLine) // 如果还没有到达底部
            {
                transform.position = new Vector3(transform.position.x, -34f, transform.position.z);
            }
            else isAtLine = true; // 设置已经到达底部
            BoundInLine();
           
        }
    }

    private void OnMouseDown()
    
    {
        if(!isAtLine)
        {
           // Debug.Log("Mouse Clicked");
        
            zPos = Camera.main.WorldToScreenPoint(transform.position).z;
            if(ifClone == false)
            {
                clone = Instantiate(gameObject);
                BarsControl someComponent = clone.GetComponent<BarsControl>();
                someComponent.ifClone = true;
            }
            else clone = gameObject;
        // 将克隆体的位置设置为被点击物体的位置
            clone.transform.position = transform.position;

        }

    
    }

    private void OnMouseDrag()
    {
        if(!isAtLine)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            clone.transform.position = new Vector3(objPos.x, objPos.y, clone.transform.position.z);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter Trigger: " + other.name);
        if (other.CompareTag("Line")) // 判断触发器是否与 line 标签匹配 获得分数值
        {
            isInLine = true;
            string str = GetComponentInChildren<TextMeshPro>().text;
            Debug.Log(str);
            myAddendDomi = int.Parse(str.Substring(str.IndexOf('/') + 1));
            myAddend = new FragAddition.Fraction { numerator = 1, denominator = myAddendDomi };

            if(!isAdded){
                GameObject.Find("GameController").GetComponent<SumTest1>().GetMyAddEnd(myAddend);
                isAdded = true;
                //GameObject.Find("BarGenerator").GetComponent<BarGroup>().SetGapPos(gameObject);
            }
        }

    }

    void BoundInLine()
    {
        Renderer renderer = GetComponentInChildren <Renderer>();
        Bounds rendererBounds = renderer.bounds;
        // 获取物体的位置
        Vector3 position = transform.position;
        // 计算物体的偏移量
        float xOffset = rendererBounds.extents.x;
        // 将物体的位置从中心点偏移半个大小
        position.x = Mathf.Clamp(position.x, LineBounds.min.x + xOffset, LineBounds.max.x - xOffset);
        // 更新物体的位置
        transform.position = position;
    }



}