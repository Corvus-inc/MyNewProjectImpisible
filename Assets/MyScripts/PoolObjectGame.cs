using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Класс нуждается в доработке. Но работает как нужно.
/// Доработка скорее всего если и будет, то посредствам пересоздания данного класса.
/// Это пул чисто из моей головы ни откуда не взятый. Способы создания человеческих
/// пулов не были изучены.
/// </summary>
public class PoolObjectGame : MonoBehaviour
{   private int poolCount;
    private List<GameObject> pool; //основной   пул
    private List<GameObject> poolTemporary;// временное хранилище переданных объектов

    public GameObject ready; //объект для передачи
    public int PoolNum { get; set; }//Размер пула


    /// <summary>
    /// Заменил скандальный конструктор на команду старта
    /// Так он прикрепляется и запускается в другом классе.
    ///  s_PoolObject = gameObject.AddComponent<PoolGameObject2>();
    ///  s_PoolObject.ready = s_BulletObject;
    ///  s_PoolObject.PoolNum = s_PoolNum;
    /// </summary>
    private void Start()
    {
        print("hi");

        

        pool = new List<GameObject>(PoolNum);
        poolTemporary = new List<GameObject>(PoolNum);
        for (int i = 0; i < PoolNum; i++)
        {
            GameObject NewObject = Instantiate(ready, Vector3.zero, Quaternion.identity);
            NewObject.SetActive(false);
            pool.Add(NewObject);
        }


    }
    public GameObject ObjectLeavePool() //Метод который извлекает из пула объекты и следит за его наполненностью. 
                                        //Как вариант, можно поставить флаг, который будет подниматься когда основной пул будет пустеть. И тогда можно будет использовать временный пул, как основной. В таком случае ссылки на объекты не нужно будет возвращать обратно - они сами туда вернутся и флаг опустится. 
    {
        poolCount = pool.Count - 1;
        if (poolCount > 0)
        {

            Flow();
            return ready;

        }
        else
        {
            Flow();
            ObjectsJoinPool();
            poolCount = 1;
            return ready;


        }
    }
    public void ObjectsJoinPool() //метод возвращает все объекты обратно в пул.
    {
        foreach (var el in poolTemporary)
        {
            pool.Add(el);

        }
        pool.Reverse();
        poolTemporary.Clear();
    }
    private void Flow() //Обеспечивает передачу ссылок на объекты из основного пула во временный.
    {
        ready = pool[poolCount];
        poolTemporary.Add(pool[poolCount]);
        pool.Remove(pool[poolCount]);
    }
}
