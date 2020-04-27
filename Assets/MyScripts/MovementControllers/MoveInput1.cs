using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput1 : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    [SerializeField]
    float speedRotate;

    [SerializeField]
    float jump;
   

    
    private Transform selfTransform;



    private void Start()
    {
        selfTransform = GetComponent<Transform>();


    }

   
    private void Update()
    {

        
        if (Input.GetKey(KeyCode.W))
        {
            
            selfTransform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            selfTransform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            selfTransform.Rotate(Vector3.down *  speedRotate * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            selfTransform.Rotate(Vector3.up *  speedRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            selfTransform.Translate(Vector3.up * Time.deltaTime *jump);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {

            selfTransform.position +=Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            selfTransform.position += Vector3.back * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            selfTransform.Rotate(Vector3.up * speedRotate * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            selfTransform.Rotate(Vector3.down * speedRotate * Time.deltaTime);
        }
    }
}
