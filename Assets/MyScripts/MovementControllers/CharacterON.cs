using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterON : MonoBehaviour
{
    public CharacterController controller;

    public float speedMove = 12f;
    
    private void Start()
    {
        
    }

   
    private void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speedMove * Time.deltaTime);

    }
}
