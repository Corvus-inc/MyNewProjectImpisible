using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// Класс реализации выстрела напрямую из пула объектов. В этом классе прописывается
/// сам объект, его сила и точка откуда он будет появляться.
/// Количество оюъектов регулируется, непосредственно, в классе создания пула объектов.
/// </summary>

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public float power;
    [SerializeField]
    public GameObject point;//Метосто появления пули в момент выстрела.

    float timeInSec = 10;
    public PoolGameObject2 NewPool;
        //int CountBullets = 99;



    void Start()
    {
        //Bullets = new List<GameObject>(100);
        //for (int i = 0; i <= 99; i++)
        //{
        //    GameObject NewBullet = Instantiate(Bullet, Vector3.zero, Quaternion.identity);

        //    Bullets.Add(NewBullet);
        //}

        //NewPool = new PoolGameObject(Bullet, 100);
         

    }
    void Update()
    {
        //if (Bullets.Count <= 0)CreateBullet();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ReadyGo = NewPool.ObjectLeavePool();
            ReadyGo.SetActive(true);
            ReadyGo.transform.position = point.transform.position;
            ReadyGo.transform.rotation = point.transform.rotation;
            ReadyGo.GetComponent<Rigidbody>().velocity = point.transform.forward * power;
            StartCoroutine(ExecuteAfterTime(timeInSec, ReadyGo));
           
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
                                                                   //Это корутина. ЕЕ нужно запускать методом StartCoroutine(). Тогда все работает.
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }

}
