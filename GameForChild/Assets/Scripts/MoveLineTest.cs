using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLineTest : MonoBehaviour
{
    public Scrollbar scrollbar;
    float scrollbarValue; 
    public bool isNeeded = false;
    float  rando;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isNeeded)
        {
            scrollbarValue = scrollbar.value;
            SetFloatSum();
        }
        rando = GameObject.Find("BarGenerator").GetComponent<BarGenerator>().rando;
        scrollbar.transform.localScale = new Vector3(rando, 1f, 1f);

    }

    public void SetFloatSum(){

            GetComponent<SumTest1>().myFloatSum = scrollbarValue;
    }
}
