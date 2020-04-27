using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    List<GameObject> Bullets;

    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject Point;


        int CountBullets = 99;


    void Start()
    {
        Bullets = new List<GameObject>(100);
        for (int i = 0; i <= 99; i++)
        {
            GameObject NewBullet = Instantiate(Bullet, Vector3.zero, Quaternion.identity);

            Bullets.Add(NewBullet);
        }
        
    }


    void Update()
    {
        //if (Bullets.Count <= 0)CreateBullet();

        if (Input.GetMouseButtonDown(0))
        {
            if (CountBullets >= 0)
            {
                Bullets[CountBullets].transform.position = Point.transform.position;
                Bullets[CountBullets].transform.rotation = Point.transform.rotation;
                Rigidbody s_rigi = Bullets[CountBullets].GetComponent<Rigidbody>();
                s_rigi.velocity = Point.transform.forward * 10;
                //s_rigi.velocity = Vector3.zero;
                //s_rigi.AddForce(Point.transform.forward);
                CountBullets -= 1;
            }
            else CountBullets = 9;
        }

    }
    private void CreateBullet()
    {
        GameObject NewBullet = Instantiate(Bullet, Vector3.zero, Quaternion.identity);
        Bullets.Add(NewBullet);
    }
}
