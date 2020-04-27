using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject go;
    private Camera goCamera;

    private float MyAngle = 0F;


    private Vector3 MousePos;
    void Update()
    {
        MousePos = Input.mousePosition;
    }



    

    void Start()
    {
        // Инициализируем кординаты мышки и ищем главную камеру
        goCamera = GetComponent<Camera>();
        //go = goCamera.transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;
            MyAngle = ((MousePos.x - (Screen.width / 2)) / Screen.width); 
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, MyAngle);
            MyAngle = ((MousePos.y - (Screen.height / 2)) / Screen.height);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -MyAngle);
        }
       
    }
    
}
