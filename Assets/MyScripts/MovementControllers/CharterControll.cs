using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharterControll : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody rig;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
             
        }
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            // Мы заземлены, так что пересчитайте
            // направление движения непосредственно от осейф
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        // Применить гравитацию. Гравитация умножается на дельтатим дважды (один раз здесь и один раз ниже
        // // когда направление движения умножается на дельтатим). Это происходит потому, что гравитация должна быть применена
        // как ускорение (МС^-2)
        moveDirection.y -= gravity * Time.deltaTime;
       
        // Move the controller
        
        characterController.Move(moveDirection * Time.deltaTime);
        
    }
}
