using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Сегодня мне очень повезло и в этом классе не и спользуются компоненты класса 
/// MonoBehaviour и я могу дописать этот контейнер с пульками и перейти к, собственно, самому
/// изъятию и выстреливанию этих пулек. Но осадочек остался.
/// </summary>

class BulletContainer
{
    private GameObject Bullet; //ПУля 
    public PoolGameObject NewPool; // Контейнер для пуль.

    public string shell { get; private set; }// Зачем мне это поле?

   
    //Реализация паттерна  одиночки, для того, чтобы этим классом пользовались отовсюду.
    private static BulletContainer instance; //Неповторимость этого класса

    private BulletContainer()
    { }

    protected BulletContainer(string shell)
    {
        this.shell = shell ;
        Bullet = GameObject.Find(shell);
        NewPool = new PoolGameObject(Bullet, 10);
    }
    public static BulletContainer getInstance(string shell)// метод который реализует неповторимость
    {
        if (instance == null)
            instance = new BulletContainer(shell);

        return instance;
    }
    //Этот класс создает массив патронов, которые будут использовать все, кто стреляет ими. Может создаться ситуация, при которой использованных патронов будет больше, чем успевает исчезнуть с поля. В таком случае, в ход могут начать идти пули, которые еще летят. Нужно создать проверку на Активность всего массива в игре и в таком случае создавать новые  копии патронов,добавлять их в массив и тут же использовать.
    //void Start()
    //{


    //    // NewPool = new PoolGameObject(Bullet, 100);
    //    getInstance("Shell 1 1");

    //}
}
