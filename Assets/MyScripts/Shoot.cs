using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    List<GameObject> Bullets;

    [SerializeField]
    GameObject Bullet;//Сюда префаб объекта.
    [SerializeField]
    GameObject Point;//Метосто появления пули в момент выстрела.

    PoolGameObject NewPool;
        //int CountBullets = 99;


    void Start()
    {
        //Bullets = new List<GameObject>(100);
        //for (int i = 0; i <= 99; i++)
        //{
        //    GameObject NewBullet = Instantiate(Bullet, Vector3.zero, Quaternion.identity);

        //    Bullets.Add(NewBullet);
        //}
        NewPool = new PoolGameObject(Bullet, 10);


    }


    void Update()
    {
        //if (Bullets.Count <= 0)CreateBullet();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ReadyGo = NewPool.ObjectLeavePool();
            ReadyGo.SetActive(true);
            ReadyGo.transform.position = Point.transform.position;
            ReadyGo.GetComponent<Rigidbody>().velocity = Point.transform.forward * 10;

            ExecuteAfterTime(0.01f, ReadyGo) ;
            //if (CountBullets >= 0)
            //{
            //    Bullets[CountBullets].transform.position = Point.transform.position;
            //    Bullets[CountBullets].transform.rotation = Point.transform.rotation;
            //    Rigidbody s_rigi = Bullets[CountBullets].GetComponent<Rigidbody>();
            //    s_rigi.velocity = Point.transform.forward * 10;
            //    //s_rigi.velocity = Vector3.zero;
            //    //s_rigi.AddForce(Point.transform.forward);
            //    CountBullets -= 1;
            //}
            //else CountBullets = 9;
        }

    }
    //private void DeleteTimeBullet()
    //{
    //    Timer del = new Timer();
        
    //}
    IEnumerator ExecuteAfterTime(float timeInSec, GameObject bull) // Это должно было работать как таймер, но не судьба. Надо разобраться.
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }

}
