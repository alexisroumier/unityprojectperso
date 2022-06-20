using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

 
public class CameraMovement : MonoBehaviour

{
   
    public Transform playerTarget;
    public Transform camTarget;
    private Vector3 point;
    public Transform y_axis;
    public Transform x_axis;
    public Transform z_axis;
    public float movementTime;
    public float rotationAmount;


    public Quaternion newRotation;

    private void Start() {
        newRotation = transform.rotation;
    }  

    public void Update ()
    {
        point = playerTarget.transform.position + new Vector3(-7.29f, 5.96f, -7.29f);
        transform.position = point;
        transform.LookAt(worldPosition: point, Vector3.up);

    /*

        if(Input.GetKeyUp(KeyCode.H))
        {
            transform.RotateAround(playerTarget.position, camTarget.position, 90f);
            iTween.RotateBy(target: camTarget.gameObject, iTween.Hash("y", 0.25f, "time",1.3f, "easetype", iTween.EaseType.linear)); 
            iTween.MoveTo(this.gameObject);
        }

    float angle = Mathf.Atan((target.position.x - transform.position.x)/(target.position.z - transform.position.z));      //Possibly wrong sign, depending on your setup
    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);

    */

    }

/*
    public void GetNextView()
    {
        newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        //newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        //transform.rotation = this.transform.rotation;
        //transform.Rotate(0, 90, 1);
       // target = target.transform.position + new Vector3() Quaternion.EulerAngles(0f, 90f, 0f);
       //transform.LookAt(point, Vector3.up);
    }

    public void AlignTo(Transform target)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove (target.position + new Vector3(-8, 10, -8), 0.75f));
        seq.Join (Camera.main.transform.DORotate (new Vector3(30f, 135f, 0f), 0.75f));
        //transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0f, 45f, 0f, 0f), 1);
        //transform.RotateAround(target.transform.position, 200 * Vector3.up, Time.deltaTime * 3000);
    }
*/

}
 