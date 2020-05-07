using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Этот скрипт специально продублирован, потому, что я потратил целый день на то чтобы
/// понять почему у меня при использовании этого скрипта несколько раз, создается 
/// несколько копий." Это же ОДИНОЧКА! Какого черта? " - кричал я. И думал что это 
/// я не правильно использую паттерн. Может пишу чего не то.... Но нет все дело в 
/// простом наследовании MonoBehaviour - оно не дает заполнить информацией этот чертов
/// private static BulletContainer instance; при каждом использовании метода, который
///  должен был идентифицировать уникальность сие класса метод не находил instance 
///  уникальным, он находил его всегда Null и всегда создавал новый экземпляр с помощью
///  конструктора... Конец.
/// </summary>
public class BulletContainer2 : MonoBehaviour
{
    
        private GameObject Bullet; //ПУля 
        public PoolGameObject NewPool; // Контейнер для пуль.

        public string shell { get; private set; }// Зачем мне это поле?


        //Реализация паттерна  одиночки, для того, чтобы этим классом пользовались отовсюду.
        private static BulletContainer2 instance; //Неповторимость этого класса

        private BulletContainer2()
        { }

        protected BulletContainer2(string shell)
        {
            this.shell = shell;
            Bullet = GameObject.Find(shell);
            NewPool = new PoolGameObject(Bullet, 10);
        }
        public static BulletContainer2 getInstance(string shell)// метод который реализует неповторимость
        {
            if (instance == null)
                instance = new BulletContainer2(shell);

            return instance;
        }
        //Этот класс создает массив патронов, которые будут использовать все, кто стреляет ими. Может создаться ситуация, при которой использованных патронов будет больше, чем успевает исчезнуть с поля. В таком случае, в ход могут начать идти пули, которые еще летят. Нужно создать проверку на Активность всего массива в игре и в таком случае создавать новые  копии патронов,добавлять их в массив и тут же использовать.
        //void Start()
        //{


        //    // NewPool = new PoolGameObject(Bullet, 100);
        //    getInstance("Shell 1 1");

        //}

        [SerializeField]
        private float power;
        [SerializeField]
        private GameObject Point;
}
