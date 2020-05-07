using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Этот класс использует контейнер, который создается за пределами класса. 
/// Каждый объект с этим скриптом будет брать патроны из этого "общего" контейнера и 
/// выстреливать их. Нужно добавить условие, которое будет заставлять создавать новые объекты
///  если все объекты из контейнера будут активны.
/// 
/// </summary>

 class DubleShoot : MonoBehaviour
{
    List<GameObject> Bullets;

    //[SerializeField]
    //private GameObject Bullet;//Сюда префаб объекта.
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject Point;//Метосто появления пули в момент выстрела.

   

    public BulletContainer shootB { get; set; }

    void Start()
    {

        
        // Запускает  метод "Одиночки". Тем самым заполняя "контейнер"
        shootB = BulletContainer.getInstance("Shell 1 1");

    }


    void Update()
    {
        //if (Bullets.Count <= 0)CreateBullet();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ReadyGo = shootB.NewPool.ObjectLeavePool();
            ReadyGo.SetActive(true);
            ReadyGo.transform.position = Point.transform.position;
            ReadyGo.transform.rotation = Point.transform.rotation;
            ReadyGo.GetComponent<Rigidbody>().velocity = Point.transform.forward * power;
            StartCoroutine(ExecuteAfterTime(5f, ReadyGo));

            
        }

    }
    
    IEnumerator ExecuteAfterTime(float timeInSec, GameObject bull) // Это должно было работать как таймер, но не судьба. Надо разобраться.
                                                                   //Это корутина. ЕЕ нужно запускать методом StartCoroutine(). Тогда все работает.
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }
}
