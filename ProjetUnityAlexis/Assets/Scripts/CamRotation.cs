using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{

    public float speed;

    public void Update ()
    {

        if(Input.GetKeyDown(KeyCode.B))
        {
            transform.Rotate(0,90,0);
        }
    }
}
