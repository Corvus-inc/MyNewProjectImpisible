using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 public class ShootController : MonoBehaviour
{

    [SerializeField]
    public GameObject s_BulletObject;
    [SerializeField]
    public int s_PoolNum;
    [SerializeField]
    public float s_PowerBullet;
    [SerializeField]
    public bool s_DontStop;
    [SerializeField]
    public GameObject s_StartPoint;
    [Range (1,1000)]
    public float s_CoolDown;

    private PoolObjectGame s_PoolObject;
    // Тут Должен быть контейфнер. Если null, то использовать s_PoolObject как компонент, если 
    private Shoot s_ShootShell;  
    
    
    
    private void Awake()
    {
        
        s_PoolObject = gameObject.AddComponent<PoolObjectGame>();
        s_PoolObject.ready = s_BulletObject;
        s_PoolObject.PoolNum = s_PoolNum;

        s_ShootShell = gameObject.AddComponent<Shoot>();
        s_ShootShell.NewPool = s_PoolObject;
        s_ShootShell.power = s_PowerBullet;
        s_ShootShell.point = s_StartPoint;
        s_ShootShell.coolDown = s_CoolDown;
        s_ShootShell.shootDontStop = s_DontStop;


    }


    private void Update()
    {

    }
}
