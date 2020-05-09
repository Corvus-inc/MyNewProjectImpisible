using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Этот класс использует контейнер, который создается за пределами класса. 
/// Каждый объект с этим скриптом будет брать патроны из этого "общего" контейнера и 
/// выстреливать их.
/// 1. Все патроны в контейнере завязаны на одном префабе. 
/// 2. Можно менять скорость, точку откуда стрелять, Но общее количество патронов и их 
/// "шкурка" останутсяя неизменны. 
/// 3. Для нового типа патронов нужно будет создавать новый скрипт.
/// 3.1 Может как-то вынести метод отправки пули в полет?
/// 4. Может быть стоит наследование тут попробовать?
/// Нужно добавить условие, которое будет заставлять создавать новые объекты
///  если все объекты из контейнера будут активны.
/// 
/// </summary>

 class DubleShoot : MonoBehaviour
{

    [SerializeField]
    private int quantity = 100 ;
    [SerializeField]
    private GameObject Bullet;//Сюда префаб объекта.
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject Point;//Метосто появления пули в момент выстрела.

   

    public BulletContainer shootB { get; set; }

    void Start()
    {

        
        // Запускает  метод "Одиночки". Тем самым заполняя "контейнер"
        shootB = BulletContainer.getInstance(Bullet, quantity);

    }


    void Update()
    {
        //if (Bullets.Count <= 0)CreateBullet();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ReadyGo = shootB.newPool.ObjectLeavePool();
            ReadyGo.SetActive(true);
            ReadyGo.transform.position = Point.transform.position;
            ReadyGo.transform.rotation = Point.transform.rotation;
            ReadyGo.GetComponent<Rigidbody>().velocity = Point.transform.forward * power;
            StartCoroutine(ExecuteAfterTime(5f, ReadyGo));

            
        }

    }
    
    IEnumerator ExecuteAfterTime(float timeInSec, GameObject bull) // Это должно было работать как таймер, но не судьба. Надо разобраться.
                                                                   //Это корутина. ЕЕ нужно было запускать методом StartCoroutine(). Тогда все работает.
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }
}
