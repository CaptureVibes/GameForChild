using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
   GameObject[] clones;
   public Scrollbar scrollbar;
   bool isNeedScroll = false;
   public void clear()
    {   
        if(isNeedScroll){
            scrollbar.value = 0;
        }
        clones = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject clone in clones) 
        {
            if (clone.name.Contains("Clone")) 
            { 
                Destroy(clone); 
            }
        }
        if(GetComponent<SumTest1>() )
           GetComponent<SumTest1>().ResetMyFloatSum();
        if(GetComponent<CuboGameControl>())
            GetComponent<CuboGameControl>().ResetMyFloatSum();

    }
}
