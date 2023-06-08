using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float  fixedLength;
    public GameObject Ending0;
    public GameObject Ending1;

    void Start()
    {

        fixedLength = GameObject.Find("GameController").GetComponent<CuboidGenerator>().fixedLength;
        
    }

    // Update is called once per frame
    void Update()
    {
        fixedLength = GameObject.Find("GameController").GetComponent<CuboidGenerator>().fixedLength;
        Vector3 EndingScale = new Vector3(fixedLength, 1f, 1f);
        transform.localScale = EndingScale;

        SetEndingPoints();

        
    }

    void SetEndingPoints(){
        Vector3 alignScale = transform.localScale;
        Vector3 moveScale0 = Ending0.transform.localScale;
        Vector3 moveScale1 = Ending1.transform.localScale;

        Vector3 alignPos = transform.position;
        Vector3 movePos0 = Ending0.transform.position;
        Vector3 movePos1 = Ending1.transform.position;

        movePos0.x = alignPos.x - (alignScale.x / 2) - (moveScale0.x / 2 ); // 对齐到对齐的 Cube 对象的右侧
        movePos1.x = alignPos.x + (alignScale.x / 2) + (moveScale0.x / 2 ); // 对齐到对齐的 Cube 对象的右侧

        Ending0.transform.position = movePos0;
        Ending1.transform.position = movePos1;
    }
}
