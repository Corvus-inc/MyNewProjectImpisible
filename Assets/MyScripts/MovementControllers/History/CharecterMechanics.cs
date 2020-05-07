using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterMechanics : MonoBehaviour
{
    public float speedMove;


    //параметры геймплея для персонажа
    private float gravityForce;
    public float gravity = 20;
    private Vector3 moveVector;

    //Ссылки на компоненты
    private CharacterController ch_controller;
    private Animator ch_animator;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGravity();
    }
    //Метод перемещение персонажа
    private void CharacterMove()
    {
        //перемещение по поверхности
        if (ch_controller.isGrounded)
        {
            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * speedMove;
            moveVector.z = Input.GetAxis("Vertical") * speedMove;

            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }
        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);//метод передвижения по направлению
    }

    //метод гравитации
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded) gravityForce -=/*20f*/gravity * Time.deltaTime;
        else gravityForce = -1f;
    }
}
