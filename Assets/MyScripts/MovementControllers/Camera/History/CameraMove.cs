using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform s_camera;
    void Start()
    {
        s_camera = GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            print("Rigt");
            s_camera.Rotate(Vector3.up);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            print("Left");
            s_camera.Rotate(Vector3.down);

        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            print("Up");
            s_camera.Rotate(Vector3.left);
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            print("Down");
            s_camera.Rotate(Vector3.right);
        }


    }
}
