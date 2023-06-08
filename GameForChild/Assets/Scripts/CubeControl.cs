using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject player;
    public GameObject Ending0;
    public GameObject Ending1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoundinArea();
        float distanceZ = Mathf.Abs(transform.position.z - player.transform.position.z);
        float distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
        if(distanceZ < 4 && distanceX < 0.3)
        {   
            Vector3 pos = transform.position;
            pos.x = player.transform.position.x;;
            transform.position = pos;
        }
        
         

    }

    private void BoundinArea() {
                
            Vector3 alignScale = transform.localScale;
            Vector3 moveScale0 = Ending0.transform.localScale;
            Vector3 moveScale1 = Ending1.transform.localScale;

            Vector3 EndingPos0 = Ending0.transform.position;
            Vector3 EndingPos1 = Ending1.transform.position;

            Vector3 cuboMove = transform.position;
            
            cuboMove.x = Mathf.Clamp(cuboMove.x, EndingPos0.x + moveScale0.x/2 + alignScale.x/2, EndingPos1.x - moveScale0.x/2 - alignScale.x/2);
            transform.position = cuboMove;
    }


}
