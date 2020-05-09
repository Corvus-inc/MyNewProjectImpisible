using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.MyScripts;

 class ShootController : MonoBehaviour
{

    [SerializeField]
    private GameObject s_BulletObject;
    [SerializeField]
    private int s_PoolNum;
    [SerializeField]
    private float s_PowerBullet;
    [SerializeField]
    private GameObject s_StartPoint;

    private PoolGameObject2 s_PoolObject;
    private BulletContainer s_PoolBullet;//Если null, то использовать s_PoolObject как компонент, если 
    private Shoot s_ShootShell;  
    
    
    
    private void Start()
    {
        
        s_PoolObject = gameObject.AddComponent<PoolGameObject2>();
        s_PoolObject.ready = s_BulletObject;
        s_PoolObject.PoolNum = s_PoolNum;

        s_ShootShell = gameObject.AddComponent<Shoot>();
        s_ShootShell.NewPool = s_PoolObject;
        s_ShootShell.power = s_PowerBullet;
        s_ShootShell.point = s_StartPoint;

    }


    private void Update()
    {

    }
}
