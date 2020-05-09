using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyScripts
{
    public class PoolGameObject:MonoBehaviour
    {
        private List<GameObject> pool; //основной   пул

        private List<GameObject> poolTemporary;// временное хранилище переданных объектов

        private GameObject ready; //объект для передачи
        private int PoolCount { get; set; }

        private void Start()
        {
            print ("hi");
        }
        public PoolGameObject(GameObject obj, int num) //Конструктор который создает пул на основе объекта и количества объектов. Объекты осоздаются не активные.
        {
            ready = obj;
            pool = new List<GameObject>(num);
            poolTemporary = new List<GameObject>(num);
            for (int i = 0; i < num; i++)
            {
                GameObject NewObject = Instantiate(ready, Vector3.zero, Quaternion.identity);
                NewObject.SetActive(false);
                pool.Add(NewObject);
            }
            

        }
        public GameObject ObjectLeavePool() //Метод который извлекает из пула объекты и следит за его наполненностью. 
            //Как вариант, можно поставить флаг, который будет подниматься когда основной пул будет пустеть. И тогда можно будет использовать временный пул, как основной. В таком случае ссылки на объекты не нужно будет возвращать обратно - они сами туда вернутся и флаг опустится. 
        {
            PoolCount = pool.Count - 1;
            if (PoolCount>0)
            {

                Flow();
                return ready;

            }
            else
            {
                Flow();
                ObjectsJoinPool();
                PoolCount = 1;
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
                ready = pool[PoolCount];
                poolTemporary.Add(pool[PoolCount]);
                pool.Remove(pool[PoolCount]);
        }
    }
}
