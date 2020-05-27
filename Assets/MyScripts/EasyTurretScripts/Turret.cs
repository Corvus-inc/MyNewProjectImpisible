using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] private TurretBullet bulletPrefab; // префаб снаряда, если его нет, то будет выбран режим стрельбы "лучом"
	[SerializeField] private float fireRate = 1; // скорострельность
	[SerializeField] private float smooth = 1; // сглаживание движения башни
	[SerializeField] private float rayOffset = 1; // делаем поисковый луч, немного больше области поиска
	[SerializeField] private float damage = 10; // повреждение (при стрельбе "лучом")
	[SerializeField] private Transform[] bulletPoint; // точки, откуда ведется стрельба
	[SerializeField] private Transform turretRotation; // объект вращения, башня турели
	[SerializeField] private Transform center; // центр между пушками, для поискового луча
	[SerializeField] private LayerMask layerMask; // фильтр коллайдеров по маске слоя
	[Header("Лимиты по осям башни:")]
	[SerializeField] private bool useLimits;
	[SerializeField] [Range(0, 180)] private float limitY = 50;
	[SerializeField] [Range(0, 180)] private float limitX = 30;
	private SphereCollider turretTrigger;
	private Transform target;
	private Vector3 offset;
	private int index;
	private float curFireRate;
	private Quaternion defaultRot = Quaternion.identity;
	private UnitHP PP;

	void Awake()
	{
		turretTrigger = GetComponent<SphereCollider>(); // Определил коллайдер в поле
		turretTrigger.isTrigger = true; // Назначел его триггером через свойство
		offset = turretTrigger.center; //Определяет ссылку на  центр Тригера
		curFireRate = fireRate;//Скорострельность передает значение в переменную без доступа из вне
		turretTrigger.enabled = true;//Включил коллайдер
		enabled = false;//Выключил класс Бихевор, для не обновления поведения. Я так полагаю это включает или выключает работоспособность Метода Update.
						//Большая часть Эвейка - формальности, которые важны, чтобы не было ошибок - Проверка систем перед запуском.
		
	}
	//После проверки на того кто оказался в триггере. Назначается трансформ объекта в Таргет и выключается триггер. Триггер как бы исчез. А обновление класса запустилось
	void OnTriggerEnter(Collider other)
	{
		if (CheckLayerMask(other.gameObject, layerMask))
		{
			target = other.transform;
			turretTrigger.enabled = false;
			enabled = true;
		}
	}

	Transform FindTarget() // возвращает ближайшую цель
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position + offset, turretTrigger.radius, layerMask);

		Collider currentCollider = null;
		float dist = Mathf.Infinity;

		foreach (Collider coll in colliders)
		{
			float currentDist = Vector3.Distance(transform.position + offset, coll.transform.position);

			if (currentDist < dist)
			{
				currentCollider = coll;
				dist = currentDist;
			}
		}

		return (currentCollider != null) ? currentCollider.transform : null;
	}

	Vector3 CalculateNegativeValues(Vector3 eulerAngles)
	{
		eulerAngles.y = (eulerAngles.y > 180) ? eulerAngles.y - 360 : eulerAngles.y;
		eulerAngles.x = (eulerAngles.x > 180) ? eulerAngles.x - 360 : eulerAngles.x;
		eulerAngles.z = (eulerAngles.z > 180) ? eulerAngles.z - 360 : eulerAngles.z;
		return eulerAngles;
	}

	bool Search() // разворот башни на цель
	{
		if (rayOffset < 0) rayOffset = 0;
		float dist = Vector3.Distance(transform.position + offset, target.position);//К позиции турели прибавляется позиция центр триггера. Таким образом, мы получаем расстояние от центра тригера до центра попавшего в него объекта. Запись во флоат в юнитах.
		Vector3 lookPos =turretRotation.position - target.position  ; // Место куда необходимо направлять положение башни турели. Точка в пространстве к которой будет стремиться башня. 
		Debug.DrawRay(turretRotation.position, center.forward * (turretTrigger.radius + rayOffset)); // Рисует линию от позиции башни турели до края триггера+1.
		Vector3 rotation = Quaternion.Lerp(turretRotation.rotation, Quaternion.LookRotation(lookPos), smooth * Time.deltaTime).eulerAngles; // Расчет плавного движения до цели.

		if (useLimits) //использует ограничения по повороту башни
		{
			rotation = CalculateNegativeValues(rotation);
			rotation.y = Mathf.Clamp(rotation.y, -limitY, limitY);
			rotation.x = Mathf.Clamp(rotation.x, -limitX, limitX);
		}

		rotation.z = 0; //Выравнивает ось при поиске. Наверное, чтобы не заваливалась?
		turretRotation.eulerAngles = rotation; // Устанавливает значение поворота. В этот момент башня сдвигается на некоторое значение.( см.лерп )

		if (dist > turretTrigger.radius + rayOffset)
		{
			target = null;
			return false;
		}

		if (IsRaycastHit(center)) return true;

		return false;
	}
	//Принимает объект и слой. Проверяет слой вошедшего объекта и слой самой турели. Сама турель не должна иметь нулевой показатель значения. Слой объекта не пройдет проверку при отрицательном значении. 
	bool CheckLayerMask(GameObject obj, LayerMask layers)
	{
		if (((1 << obj.layer) & layers) != 0)
		{
			Debug.Log(layers.value);
			return true;
		}

		return false;
	}

	bool IsRaycastHit(Transform point)//Создается проверка на вхождение невидимого луча в нужный объект.
	{
		RaycastHit hit;
		Ray ray = new Ray(point.position, point.forward);
		if (Physics.Raycast(ray, out hit, turretTrigger.radius + rayOffset))
		{
			if (CheckLayerMask(hit.transform.gameObject, layerMask))
			{
				return true;
			}
		}

		return false;
	}

	void Shot()
	{
		if (!Search()) return;

		curFireRate += Time.deltaTime;
		if (curFireRate > fireRate)
		{
			Transform point = GetPoint();
			curFireRate = 0;

			if (bulletPrefab != null)
			{
				TurretBullet bullet = Instantiate(bulletPrefab, point.position, Quaternion.identity) as TurretBullet;
				bullet.SetBullet(layerMask, point.forward);
			}
			else if (IsRaycastHit(point))
			{
				target.GetComponent<UnitHP>().Adjust(-damage);
			}
		}
	}

	void Choice()
	{
		curFireRate = fireRate;

		target = FindTarget();

		turretRotation.rotation = Quaternion.Lerp(turretRotation.rotation, defaultRot, smooth * Time.deltaTime);

		if (Quaternion.Angle(turretRotation.rotation, defaultRot) == 0)
		{
			turretRotation.rotation = defaultRot;
			turretTrigger.enabled = true;
			enabled = false;
		}
	}

	Transform GetPoint()
	{
		if (index == bulletPoint.Length - 1) index = 0; else index++;
		return bulletPoint[index];
	}

	void LateUpdate()
	{
		if (target != null) Shot(); else Choice();
	}
}
