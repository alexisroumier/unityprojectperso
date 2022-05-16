using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;

    private void Update() {
        GatherInput();
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move() {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}


/*
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

*/