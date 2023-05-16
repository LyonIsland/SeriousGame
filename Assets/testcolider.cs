using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcolider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("!!!");
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("!!");
    }
}
