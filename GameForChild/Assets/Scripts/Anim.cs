using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Anim : MonoBehaviour
{
    public GameObject BarInstance;
    public GameObject objectToPlace;
    public GameObject leftPos;

    public GameObject gameController;
    public GameObject sumPanel;
    public int numberOfObjects = 10;
    
    GameObject Bar;
    public bool isMoving = false;
    float moveSpeed = 20f;
    Vector3 initialPos;
    Vector3 objectPosition;

    

    void Start()
    {
        StartCoroutine(GenerateBars()); // 启动协程
    }

    IEnumerator GenerateBars()
    {
        for (int i = 2; i < 11; i++)
        {
            ClearLines();
            lineGenerator(i);
            BarGenerator(i);
            yield return new WaitForSeconds(6f); // 等待 8 秒
        }
        StartGame();
    }

    void Update()
    {
        // 如果正在移动物体，则更新其位置
        if (isMoving)
        {
            Debug.Log("isMOVING");
            float step = moveSpeed * Time.deltaTime;
            Bar.transform.position = Vector3.MoveTowards(Bar.transform.position, objectPosition, step);

            // 如果物体已经到达目标位置，则停止移动
            if (Bar.transform.position == objectPosition)
            {
                isMoving = false;
                BarsControl barControl = Bar.AddComponent<BarsControl>();
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    void lineGenerator(int numberOfObjects)
    {
                // 计算物体之间的间距
        float interval = (61f - (-61f)) / (numberOfObjects);

        // 在 x 方向上均匀排列物体
        for (int i = 1; i < numberOfObjects; i++)
        {
            // 计算当前物体的位置
            float xPos = -61f + 12.6f + i * interval;
            Vector3 position = new Vector3(xPos, -37f, 0f);

            // 实例化物体并设置位置
            GameObject obj = Instantiate(objectToPlace);
            
            // 如果需要，可以设置物体的父级
            obj.transform.parent = transform;
            obj.transform.position = position;
        }
    }

    void BarGenerator(int numberOfObjects)
    {
            GameObject newGameObject = Instantiate (BarInstance);
            Bar = newGameObject;
    
            //更改颜色
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            Bar.GetComponentInChildren<SpriteRenderer>().color = randomColor;
            //更改大小
            Vector3 vecScale = new Vector3 (1f/numberOfObjects ,1f,1f);
            Bar.GetComponentInChildren<SpriteRenderer>().transform.localScale= vecScale ;
            //更改boxcollider大小
            BoxCollider2D boxCollider = Bar.GetComponentInChildren<BoxCollider2D>();
            Vector2 newSize = new Vector2(boxCollider.size.x / numberOfObjects ,boxCollider.size.y);
            boxCollider.size = newSize;
            //移动位置
            Renderer renderer = Bar.GetComponentInChildren <Renderer>();
            Bounds rendererBounds = renderer.bounds;
            float xOffset = rendererBounds.extents.x;
            initialPos = new Vector3(-61f + 12.6f + xOffset, -37f, 0);
            Bar.transform.position = initialPos; 

            float yDistance = 35.0f - (numberOfObjects - 2)*7;
            float xDistance = -70.0f + (float)((60f * BarInstance.transform.localScale.x / 6.4) / numberOfObjects);
            objectPosition = new Vector3(xDistance,yDistance,0.0f);
            //Bar.transform.position = objectPosition; 

            //更改名字
            string number = "1/"+ numberOfObjects.ToString();
            Bar.name = number;
            Bar.GetComponentInChildren<TextMeshPro>().text = number;
            StartCoroutine(Waiting());

    }

    void ClearLines()
    {
                // 查找所有名字包含 "LineGap" 的游戏对象
        GameObject[] lineGaps = GameObject.FindGameObjectsWithTag("LineGap");

        // 销毁这些游戏对象
        foreach (GameObject lineGap in lineGaps)
        {
            Destroy(lineGap);
        }
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f); // 
        StartMoving();
    }

    void StartGame()
    {
        gameController.SetActive(true);
        sumPanel.SetActive(true);
        ClearLines();
    }


}