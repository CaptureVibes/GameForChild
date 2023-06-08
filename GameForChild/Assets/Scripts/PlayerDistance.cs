using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    public GameObject player;
    public GameObject Cubo;
    public float number;
    public float distance;
    public  Vector3 originalSize;
    public float length;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CuboGameControl>().CuboIsIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        originalSize = Cubo.transform. parent.localScale;
        length = originalSize.x * transform.localScale.x;
        distance =Mathf.Abs(player.transform.position.x - Cubo.transform.position.x);
        number = distance/(length);
        GetComponent<CuboGameControl>().myFloatSum = number;
    }

    bool isInCubo(){
        float isIn = Vector3.Distance(player.transform.position, Cubo.transform.position);
        if (isIn < 2f)
            return true;
        else return false;
    }

}
