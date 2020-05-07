using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensetivity = 100f;

    //public Transform playerBody; //Тело объекта к которому прикрепленна камера
    public Transform camTransform; //Если прикрепить примитивный объект, то он будет управляться мышью без кнопок.

    float xRotation = 0f;

    float yRotation = 0f;
    
    private void Start()
    {
        //camTransform = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;//Блокирует мышь внутри запущеной сцены.
    }

    
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;//получает значение смещения по оси +или-.
        float mouseY= Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;//смещает предыдущее значение положения оси
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//не позволяет значению смещения выходить за пределы числа 90 - 180° поворот.
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        camTransform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); //Меняет положение оси, испольуя значения. Local - использует значение направления родителя.


        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //playerBody.Rotate(Vector3.up * mouseX);//Код который запускает поворот объекта камерой. Нужно убрать  yRotation из кода.

    }
}
