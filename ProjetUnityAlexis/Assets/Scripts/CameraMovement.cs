using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class CameraMovement : MonoBehaviour {
   
    //Script test pour créer une caméra qui se déplace sur un nouvelle angle lorsqu'on clique sur un bouton

    public Transform target;//the target object
    private float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
   
    void Start () {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
    }

    //public void GetNextView()
    //{
       //transform.LookAt(point, Vector3.right, Time.deltaTime, speedMod);
    //}

}
 