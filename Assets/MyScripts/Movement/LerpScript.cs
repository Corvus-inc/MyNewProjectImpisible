using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform s_objectPosition;
    [SerializeField]
    private Transform s_positionStop;
    [SerializeField]
    private float s_speed = 0.5f;
#pragma warning restore 0649

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            s_objectPosition.position = Vector3.Lerp(s_objectPosition.position, s_positionStop.position, Time.deltaTime * s_speed);
        }
    }
}
