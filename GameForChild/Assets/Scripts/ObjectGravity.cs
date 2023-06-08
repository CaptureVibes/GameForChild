using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    public float criticalValue;

    void Update()
    {
        Landing();
    }

    void Landing(){
        if(transform.position.y <= criticalValue || transform.position.y > criticalValue)
        {
             Vector3 currentPosition = transform.position;
             currentPosition.y = criticalValue;
             transform.position = currentPosition;
        }
    }
}

