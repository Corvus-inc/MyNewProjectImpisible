using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int damage;
    public float fireForce;
    public float rechargeTime;
    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            // other.transform.parent.GetComponent<TerretController>().GetHit(damage);
            Destroy(gameObject);
        }
    }



}
