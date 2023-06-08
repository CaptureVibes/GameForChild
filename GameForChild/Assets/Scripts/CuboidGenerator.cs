using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuboidGenerator : MonoBehaviour
{
    GameObject[] Cuboids = new GameObject[9];
    public GameObject baseCuboid;
    public GameObject EndingCuboid;
    public float fixedLength;
    public float spacing = 2f;
    public bool NeedCubos = true;

    private void Start()
    {
        //SizeFitting();
        
        GenerateOnce();
        




    }

    public void FixedLengthGenerator(){
        fixedLength = Random.Range(8f, 11f);
    }

    public  void GenerateOnce()
    {
        FixedLengthGenerator();
        if(NeedCubos){
            for (int i = 0; i < 9; i++)
            {   
                GameObject newGameObject = Instantiate(baseCuboid);
                Cuboids[i] = newGameObject;
                // 更改颜色
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                Cuboids[i].GetComponentInChildren<Renderer>().material.color = randomColor;
                // 更改大小
                Vector3 vecScale = new Vector3(fixedLength / (i+2), 1f, 1f);
                Transform firstChildTransform = Cuboids[i].transform.GetChild(0);
                firstChildTransform.transform.localScale = vecScale;
                // 移动位置
                float zDistance = 12.0f - i * spacing;
                float xDistance = -20.0f + (float)(fixedLength / (2*(i+2)));
                Vector3 objectPosition = new Vector3(xDistance, 0.5f, zDistance);
                Cuboids[i].transform.position = objectPosition;
                // 更改名字
                string number = "1/" + (i+2).ToString();
                Cuboids[i].name = number;
                Cuboids[i].GetComponentInChildren<TextMeshPro>().text = number;
                firstChildTransform.gameObject.name = number;
                
                Transform secondChildTransform = Cuboids[i].transform.GetChild(1);
                secondChildTransform.transform.position = new Vector3 (-19f, 0.1f, objectPosition.z);
            }
        }
    }
    
    public void ClearTargetBars()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject bar in bars)
        {
            Destroy(bar);
        }
    }

}