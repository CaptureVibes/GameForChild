using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // 玩家移动速度
    bool isChoosing = false;
    bool isMoving = false;


    CuboidsControl CuboidController;
    public GameObject myCuboid = null;
    public GameObject baseCuboid;
    public bool isPickedUp = false;
    public bool isMovingCubo = false;

    void Update()
    {
        MoveMent();

        if(isChoosing){
            if (Input.GetKeyDown(KeyCode.Space)){
                myCuboid = CuboidController.InstantiateCuboid();
//                Debug.Log(myCuboid.name);
                isChoosing = false;
                isMovingCubo = true;
            }
        }

        if(isMovingCubo){
            if (Input.GetKeyDown(KeyCode.Space)){
                if(!isPickedUp){
                    MoveCuboid();
                }
                else{
                    LayCuboid();
                }  
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(myCuboid == null){
            if(other.CompareTag("Obstacles") && !other.gameObject.name.Contains("clone")){
                baseCuboid = other.gameObject;
                CuboidsControl otherCuboid = other.gameObject.GetComponent<CuboidsControl>();
                CuboidController = otherCuboid;
                isChoosing = true;
                
            }
        }
    }

    void SetAsChild(GameObject child){
        Transform parentTransform = transform;
        Transform childTransform = child.transform;
        childTransform.SetParent(parentTransform);
        
    }

    void MoveMent(){
        // 获取方向键输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0.0f || verticalInput != 0.0f){
            isMoving = true;
        }
        else{
            isMoving = false;
        }

        // 计算移动方向
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // 根据移动方向和速度移动玩家
        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }

    void MoveCuboid(){
            SetAsChild(myCuboid);
            Rigidbody myCuboRb = myCuboid.GetComponent<Rigidbody>();
            myCuboid.GetComponent<ObjectGravity>().criticalValue = 2f;
            myCuboid.transform.position = transform.position + new Vector3(0, 2.0f, 1.0f);
            isPickedUp = true;

    }

    void LayCuboid(){
        myCuboid.transform.SetParent(null);
        myCuboid.GetComponent<ObjectGravity>().criticalValue = 0.5f;
        myCuboid = null;
        isPickedUp = false;
        baseCuboid.GetComponent<CuboidsControl>().isUp = true;
        
    }



    
}
