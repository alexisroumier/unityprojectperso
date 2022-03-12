using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{

    private CharacterController cc;
    public float moveSpeed;
    public float gravity;
    private Vector3 movedir;
    private Animator anim;
    bool IsWalking = false;


    // Start is called before the first frame update
    void Start()
    {
    cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movedir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, movedir.y, Input.GetAxis("Vertical") * moveSpeed);

        movedir.y -= gravity * Time.deltaTime;

        if (movedir.x != 0 || movedir.z != 0)
        {
            IsWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(movedir.x, 0, movedir.z)), 0.15f);
        }
else
        {
            IsWalking = false;
        }
        cc.Move(movedir * Time.deltaTime);
    }
}
