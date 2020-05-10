using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Скрифпт турели имеет два варианта поворота объекта. Если на оъекте висит Rigidbody, то обыект по завершении поворота продолжает  двигаться в направлении.... Куда-то..
/// 
/// </summary>
public class TurellScript : MonoBehaviour
{
    private Transform player;
    private Transform thisTransform;

    public float rotationSpeed = 100;
    
    public Shoot ThisShoot;

    private void Start()
    {
        ThisShoot = GetComponent<Shoot>();
        thisTransform = GetComponent<Transform>();
    }

    
    private void Update()
    {

        
        if (player != null)
        {
            
            //thisTransform.LookAt(player);//быстрый поворот объекта
            Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
       
        if (other.tag != "Player")
            return; 
        print("HelloPlayer");
        
        player = other.GetComponentInParent<Transform>();

        ThisShoot.shootDontStop = true;



    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag != "Player")
            return;
        print("exitPlayer");
        ThisShoot.shootDontStop = false;
        player = null;

    }
}
