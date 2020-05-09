using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Тупой копапаст. Потом Правкой позже займусь.
/// </summary>
 class ShootTurel : MonoBehaviour
{
    [SerializeField]
    private int quantity = 100;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject Point;//Метосто появления пули в момент выстрела.


    bool AfTime = false;
    public BulletContainer shootB { get; set; }

    void Start()
    {


        // Запускает  метод "Одиночки". Тем самым заполняя "контейнер"
        shootB = BulletContainer.getInstance(Bullet, quantity);

    }


    void Update()
    {
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;
        if (AfTime == false)
        {
            AfTime = true;
            GameObject ReadyGo = shootB.newPool.ObjectLeavePool();
            ReadyGo.SetActive(true);
            ReadyGo.transform.position = Point.transform.position;
            ReadyGo.transform.rotation = Point.transform.rotation;
            ReadyGo.GetComponent<Rigidbody>().velocity = Point.transform.forward * power;
            StartCoroutine(ExecuteAfterTime(5f, ReadyGo));
            StartCoroutine(AfterTime(1f));
            
        }

    }

    IEnumerator ExecuteAfterTime(float timeInSec, GameObject bull) // Это должно было работать как таймер, но не судьба. Надо разобраться.
                                                                   //Это корутина. ЕЕ нужно было запускать методом StartCoroutine(). Тогда все работает.
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }
    IEnumerator AfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        AfTime = false;
    }
}
