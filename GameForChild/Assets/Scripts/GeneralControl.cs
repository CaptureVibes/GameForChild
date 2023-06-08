using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralControl : MonoBehaviour
{
    public TextMeshProUGUI myLevel;
    public TextMeshProUGUI myCaught;
    public int flag;


    void Update()
    {
        if(flag == 1){
            myLevel.text = GetComponent<SumTest1>().levelCount.ToString();
            myCaught.text = GetComponent<SumTest1>().winCount.ToString();
        }
        if(flag ==2){
            myLevel.text = GetComponent<CuboGameControl>().levelCount.ToString();
            myCaught.text = GetComponent<CuboGameControl>().winCount.ToString();
        }

    }


}
