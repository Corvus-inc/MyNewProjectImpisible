using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImput2 : MonoBehaviour
{
    private Rigidbody rig;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedRotate;


    
    private float force;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    
    private void Update()
    {
        
        if (Input.GetButton("Vertical"))
        {
            force = Input.GetAxis("Vertical");
            rig.MovePosition(rig.position+transform.forward *force*Time.deltaTime*speed);
        }
        if(Input.GetButton("Horizontal"))
        {
            force = Input.GetAxis("Horizontal");
            Quaternion turnRotation = Quaternion.Euler(0f, speedRotate * force, 0f);
            rig.MoveRotation(rig.rotation * turnRotation);
        }


    }
}
