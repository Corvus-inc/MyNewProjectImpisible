using Complete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UnitHP : MonoBehaviour
{
    [SerializeField] private float health;

    [SerializeField] public bool PlayerHealth = false;//Если включена, то изменение поля heals влияет на цвет индикатора.
    [SerializeField] Text HealthText;//Индикатор жизни игрока 
    private float maxValue;
    private float s_damage;

    public float currentHealth
    {
        get { return health; }
    }

    public void Start()
    {
        maxValue = health;
    }

    public void Adjust(float value)
    {
        health += value;
        if (PlayerHealth)
        {
            HealthText.color = Color.Lerp(Color.red, Color.green, health /maxValue);
        }
        DetectToDestroyGameObject();

    }
   
    public void DetectToDestroyGameObject()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
