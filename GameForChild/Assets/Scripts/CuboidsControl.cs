using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboidsControl : MonoBehaviour
{
    private GameObject clone;
    public bool isClone = false;
    public bool isUp = true;
    public int myAddendDomi;
    public FragAddition.Fraction myAddend;

    public bool isInLine = false ;
    public bool isAtLine = false;
    bool isPickedUp = false;
    bool isAdded = false;

    public GameObject Ending0;
    public GameObject Ending1;
    bool isIN = false;
    GameObject player;


    Rigidbody rb;

    private void Start() {
        LastCuboid.lastCubo = GameObject.Find("EndPoint 0");
        player = GameObject.Find("Player");
        Ending0 = GameObject.Find("EndPoint 0");
        Ending1 = GameObject.Find("EndPoint 1");
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update() {
        if(isIN && isClone) 
        {
            BoundinArea();
        }
        isPickedUp = GameObject.Find("Player").GetComponent<PlayerControl>().isPickedUp ;
        if(!isClone){
            if(!isUp){
            MoveDown();
            }
        }

        if(!isPickedUp){
            if(isInLine)
            {
                if(isClone) BoundinArea();
                if (!isAtLine) // 如果还没有到达底部
                {   
                    Debug.Log(LastCuboid.lastCubo.name);
                    transform.position = new Vector3(PosCubo() + this.GetComponent<MeshRenderer>().bounds.extents.x, transform.position.y, 20.0f);
                    isAtLine = true;
                }
                if(isAtLine)
                {
                    LastCuboid.lastCubo = this.gameObject;
                }
            }
        }

    }

    public GameObject InstantiateCuboid()
    {
        //zPos = Camera.main.WorldToScreenPoint(transform.position).z;
        if(isClone == false)
        {
            clone = Instantiate(gameObject);
            CuboidsControl someComponent = clone.GetComponent<CuboidsControl>();
            someComponent.isClone = true;
        }
        else clone = gameObject;
        Vector3 spawnPos = GameObject.Find("Player").transform.position;
        clone.transform.position = spawnPos + new Vector3(0f,3f,1f);    
        //clone.transform.position = new Vector3(0f,4f,0f);   
        isUp = false;
        return clone;
    }

    void MoveDown(){
        transform.position = new Vector3 (transform.position.x, - 10f,transform.position.z);
    }

    void MoveUp(){
        transform.position = new Vector3 (transform.position.x, 0.5f, transform.position.z);
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Player" && isClone && player.GetComponent<PlayerControl>().isPickedUp ==false)
        {
            other.GetComponent<PlayerControl>().myCuboid = this.gameObject;
        }
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Finish"))
        {
            Debug.Log("撞到边界 ");
            isIN = true;
        }
        if(!isPickedUp){
            if (other.CompareTag("Line")) // 判断触发器是否与 line 标签匹配 获得分数值
            {
                isInLine = true;
//                Debug.Log("Enter Trigger: " + other.name);
            // isInLine = true;
                string str = gameObject.name;
                //Debug.Log(str);
                myAddendDomi = Str2Num(str);
                //Debug.Log(myAddendDomi);
                myAddend = new FragAddition.Fraction { numerator = 1, denominator = myAddendDomi };

                GameObject.Find("GameController").GetComponent<CuboGameControl>().CuboIsIn = true;
                GameObject.Find("Player").GetComponent<PlayerControl>().isMovingCubo = false;
               

                if(!isAdded){
                    GameObject.Find("GameController").GetComponent<CuboGameControl>().GetMyAddEnd(myAddend);
                    isAdded = true;
                }

                GameObject.Find("Player").GetComponent<PlayerControl>().myCuboid = null;
            }
       }
            if (other.gameObject.name == "Player" && isClone && player.GetComponent<PlayerControl>().isPickedUp ==false)
            {
                other.GetComponent<PlayerControl>().myCuboid = this.gameObject;
            }

    }

    int Str2Num(string number){
        string myString = number;
        int startIndex = myString.IndexOf("/") + 1;
        int endIndex = myString.IndexOf("(");
            string numberString = myString.Substring(startIndex, endIndex - startIndex);
            int num;
            num = int.Parse(numberString);
        return num;
    }

    private void BoundinArea() { 
            Vector3 alignScale = transform.localScale;

            Vector3 moveScale0 = Ending0.transform.localScale;
            Vector3 moveScale1 = Ending1.transform.localScale;

            Vector3 EndingPos0 = Ending0.transform.position;
            Vector3 EndingPos1 = Ending1.transform.position;

            Vector3 cuboMove = transform.position;
            
            cuboMove.x = Mathf.Clamp(cuboMove.x, EndingPos0.x + moveScale0.x/2 + alignScale.x/2, EndingPos1.x - moveScale0.x/2 - alignScale.x/2);
            //cuboMove.x = 
            transform.position = cuboMove;
    }

    float PosCubo()
    {
        MeshRenderer cubeRenderer = LastCuboid.lastCubo.GetComponent<MeshRenderer>();
        float rightBoundary = cubeRenderer.bounds.max.x;
        return rightBoundary;
    }


}
