
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// Класс реализации выстрела напрямую из пула объектов. В этом классе прописывается
/// сам объект, его сила и точка откуда он будет появляться.
/// Количество оюъектов регулируется, непосредственно, в классе создания пула объектов.
/// 
/// Было бы неплохо сделать выбор кнопки для выстрела.
/// </summary>

public class Shoot : MonoBehaviour
{ 
    [SerializeField]
    public float power;
    [SerializeField]
    public GameObject point;//Место появления пули в момент выстрела.

    float timeInMsec = 10;
    public PoolObjectGame NewPool;
    public bool shootDontStop = false;
    [Range(1, 1000)]
    public float coolDown = 100f;
    private bool coolDownFlag = true;
    
    void Start()
    {
                

    }
    void Update()
    {
        if (shootDontStop == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartShoot();

            } 
        }
        else StartShoot();
    }
    
    //Метод отправляющий пулю в полет.
    public void StartShoot()
    {
        if (coolDownFlag == true)
        {
            GameObject ReadyGo = NewPool.ObjectLeavePool(); //Взять объект из пула.
           
            StartCoroutine(OffAfterTime(timeInMsec, ReadyGo));//Запустить таймеры.
            StartCoroutine(StartAfterTime(coolDown*Time.deltaTime));
            coolDownFlag = false;
         
            ReadyGo.SetActive(true);// Включить объект. Спозиционировать и отправить в полет.
            ReadyGo.transform.position = point.transform.position;
            ReadyGo.transform.rotation = point.transform.rotation;
            ReadyGo.GetComponent<Rigidbody>().velocity = point.transform.forward * power;
            
        }

    }
    //Это корутина. ЕЕ нужно запускать методом StartCoroutine(). Тогда все работает.
    IEnumerator OffAfterTime(float timeInSec, GameObject bull) 
    {
        yield return new WaitForSeconds(timeInSec);
        bull.SetActive(false);
    }
    IEnumerator StartAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        coolDownFlag = true;
    }
}
