using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarGenerator : MonoBehaviour
{
    public bool needBars;
    GameObject[] Bars = new GameObject[9];
    public GameObject baseBar;
    public float fixedLength = 40f;
    public float spacing = 7f;

    GameObject BarInstance;
    public float rando;

    public GameObject buttomLine;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject line;

    public Vector3 leftPointPos;
    public Vector3 rightPointPos;
    public Vector3 lineSca;
    Vector2 boxColliderSizeBase;

    public bool needOnce = true;


    private void Start()
    {   
        leftPointPos = leftPoint.transform.position;
        rightPointPos = rightPoint.transform.position;
        lineSca = line.transform.localScale;
        boxColliderSizeBase = buttomLine.GetComponent<BoxCollider2D>().size;
        if(needOnce) GenerateOnce();
    }

    void SizeFitting(float rando)
    {
        Vector3 leftPos = leftPointPos;
        leftPos.x = leftPos.x + 61f * (1 - rando);
        leftPoint.transform.position = leftPos;

        Vector3 rightPos = rightPointPos;
        rightPos.x = rightPos.x - 61f * (1 - rando);
        rightPoint.transform.position = rightPos;

        Vector3 lineScale = lineSca;
        lineScale.y = 20.4f * rando;
        line.transform.localScale = lineScale;

        BoxCollider2D boxCollider = buttomLine.GetComponent<BoxCollider2D>();
        Vector2 boxColliderSize = boxColliderSizeBase; 
        boxColliderSize.x *= rando;
        boxCollider.size = boxColliderSize;
    }

    public void GenerateOnce()
    {
        GetRando();
        BarInstance = Instantiate(baseBar);
        BarInstance.transform.localScale = new Vector3(6.4f * rando, 0.4f, 1); // 设置缩放
        SizeFitting(rando);

        if(needBars)
        {
            for (int i = 0; i < 9; i++)
            {   
                //ClearTargetBars();
                GameObject newGameObject = Instantiate (BarInstance);
                Bars[i] = newGameObject;
                //更改颜色
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                Bars[i].GetComponentInChildren<SpriteRenderer>().color = randomColor;
                //更改大小
                Vector3 vecScale = new Vector3 (1f/(i+2) ,1f,1f);
                Bars[i].GetComponentInChildren<SpriteRenderer>().transform.localScale= vecScale ;
                //更改boxcollider大小
                BoxCollider2D boxCollider = Bars[i].GetComponentInChildren<BoxCollider2D>();
                Vector2 newSize = new Vector2(boxCollider.size.x / (i+2f) ,boxCollider.size.y);
                boxCollider.size = newSize;
                //移动位置
                float yDistance = 35.0f - i*spacing;
                float xDistance = -70.0f + (float)((60f * BarInstance.transform.localScale.x / 6.4) /(i+2));
                Vector3 objectPosition = new Vector3(xDistance,yDistance,0.0f);
                Bars[i].transform.position = objectPosition; 
                //更改名字
                string number = "1/"+ (i+2).ToString();
                Bars[i].name = number;
                Bars[i].GetComponentInChildren<TextMeshPro>().text = number;
            }
        }
        Destroy(BarInstance);
    }

    public void ClearTargetBars()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("Bar");
        foreach (GameObject bar in bars)
        {
            Destroy(bar);
        }
    }

    void GetRando()
    {
        rando = Random.Range(0.7f,1.0001f);
    }
}