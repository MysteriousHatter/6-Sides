using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCube : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        collisionInfo.gameObject.transform.parent = gameObject.transform;
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        collisionInfo.gameObject.transform.parent = null;
    }
}
