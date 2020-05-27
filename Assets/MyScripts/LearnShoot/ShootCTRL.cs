using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class ShootCTRL : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] shells;
    [SerializeField] private GameObject shootEffect;

    private int currentShell;
    private GameObject shellPrefab;
    private float fireForce;
    private float rechargeTime;
    private float rechargeTimer;
   

    void Start()
    {
        currentShell = 0;
        SetShell();
        
    }

    void Update()
    {
        rechargeTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)&& rechargeTimer>rechargeTime)
        {
            GameObject shell = Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject;

            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = fireForce * firePoint.forward;
            rechargeTimer = 0;

        }
        if (Input.GetMouseButtonDown(1))
        {
            currentShell++;
            if (currentShell >= shells.Length)
                currentShell = 0;
            SetShell();
        }

    }

    private void SetShell()
    {
        shellPrefab = shells[currentShell];
        Shell shell = shellPrefab.GetComponent<Shell>();
        fireForce = shell.fireForce;
        rechargeTime = shell.rechargeTime;
    }

   
}
