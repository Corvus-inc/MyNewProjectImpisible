using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Добавить  компонент типа Rigidbody

public class TurretBullet : MonoBehaviour
{

	[SerializeField] private float damage = 10;
	[SerializeField] private float bulletSpeed = 5;
	private LayerMask layer;

	public void SetBullet(LayerMask layerMask, Vector3 direction)
	{
		layer = layerMask;
		Rigidbody body = GetComponent<Rigidbody>();
		body.useGravity = false;
		body.velocity = direction * bulletSpeed;
		transform.up = direction;
	}

	void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger)
		{
			
			if (((1 << other.gameObject.layer) & layer) != 0)
			{
				other.GetComponent<UnitHP>().Adjust(-damage);
			}

			Destroy(gameObject);
		}
	}
}