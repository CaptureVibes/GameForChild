using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarGroup : MonoBehaviour
{
    public GameObject gap;
    public Transform ending0;
    private void Start() {
        gap.transform.position = ending0.position;
    }

    public void SetGapPos(GameObject newOne)
    {
        Vector3 newPosition = new Vector3(newOne.transform.position.x + newOne.GetComponent<BoxCollider2D>().bounds.size.x/2, newOne.transform.position.y, newOne.transform.position.z);
        gap. transform.position = newPosition;
    }
}


