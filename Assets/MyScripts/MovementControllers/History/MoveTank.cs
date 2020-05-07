using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    private Transform obj;
    private float speed = 5f;

    void Start()
    {
        obj = GetComponent<Transform>();
        speed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Hi2");
            obj.transform.position += Vector3.back;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("Hi333");
            obj.position += new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.W))
        {
            //print("Hi2");
            //obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            obj.position = new Vector3(0, 5, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            print("Hi1");
            obj.transform.Translate(Vector3.Lerp(Vector3.zero, Vector3.up, 0.05f));
            Vector3.MoveTowards(Vector3.zero, new Vector3(0,5,0), 0.05f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //obj.transform.Translate(Vector3.back * Time.deltaTime);
            //obj.position += new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
            obj.position = Vector3.Lerp(Vector3.back, new Vector3(0, 5, 0), (speed+1)/Time.time);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("Hi3");
            obj.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * speed, 0));

        }
        if (Input.GetKey(KeyCode.A))
        {
            obj.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * speed, 0));

        }
        //if (Input.GetButton("Vertical"))
        //{
        //    print("Hi1");
        //    obj.transform.position += new Vector3(0 , 0,Time.deltaTime * speed);

        //}



    }
}
