using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using UnityEngine;

namespace Assets.MyScripts
{
    class PoolGameObject:MonoBehaviour
    {
        List<GameObject> pool;

        List<GameObject> poolTemporary;

        GameObject ready;

        int PoolCount { get; set; }
    

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
        public GameObject ObjectLeavePool() //Метод который изымает из пула объект. 
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
                PoolCount = 10;
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
        private void Flow() //Обеспечивает передачу ссылок из основного пула во временный.
        {
                ready = pool[PoolCount];
                poolTemporary.Add(pool[PoolCount]);
                pool.Remove(pool[PoolCount]);
        }
    }
}
