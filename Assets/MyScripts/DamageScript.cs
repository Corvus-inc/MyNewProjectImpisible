using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
