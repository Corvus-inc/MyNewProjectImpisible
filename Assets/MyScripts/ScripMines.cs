using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripMines : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;//Выбрать слой игрока. Чтобы скрипт срабатывл только на этот слой
    [SerializeField]
    public float damage;//Урон от мины

    private UnitHP into;

    private void OnTriggerExit(Collider other)
    { 
        // Простейшая проверка по слою. Если входящих слоев назначить несколько, то может просто нее работать такая проверка.
        if (1<<other.gameObject.layer == layerMask.value) 
        {
            into = other.gameObject.GetComponent<UnitHP>();
            into.Adjust(-damage); 
        }    
    }


}
