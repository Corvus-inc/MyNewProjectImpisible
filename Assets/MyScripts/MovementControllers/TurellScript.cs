using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurellScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public float rotationSpeed = 100;
    

    private void Start()
    {
        
    }

    
    private void Update()
    {

        // transform.LookAt(player);//быстрый поворот объекта
        if (player != null)
        {
            Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        player = other.transform; 
        print("Hello");

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;
        player = null;

    }


    private void TurelTurn(GameObject Player)
    {

    }
}
