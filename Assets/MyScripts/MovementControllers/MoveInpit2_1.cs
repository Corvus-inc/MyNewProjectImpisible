using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInpit2_1 : MonoBehaviour
{
    private Rigidbody rig;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedRotate;

    private Transform tran;

    private float force;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        tran = GetComponent<Transform>();
    }


    private void Update()
    {

        if (Input.GetButton("Vertical2"))
        {
            force = Input.GetAxis("Vertical2");
            rig.MovePosition(rig.position + transform.forward * force * Time.deltaTime * speed);
        }
        if (Input.GetButton("Horizontal2"))
        {
            force = Input.GetAxis("Horizontal2");
            Quaternion turnRotation = Quaternion.Euler(0f, force, 0f);
            tran.Rotate(tran.rotation * (speedRotate * Vector3.up * force));
        }


    }
}
