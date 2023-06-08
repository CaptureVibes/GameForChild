using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groups : MonoBehaviour
{
        Vector3 NewPos(GameObject other)
    {
        Vector3 thePos = transform.position;
        Vector3 theScale = transform.localScale;

        Vector3 othePos = other.transform.position;
        Vector3 otherScale = other.transform.localScale;

        thePos.x = othePos.x + otherScale.x/2 + theScale.x/2;
        return thePos;
    }
}
