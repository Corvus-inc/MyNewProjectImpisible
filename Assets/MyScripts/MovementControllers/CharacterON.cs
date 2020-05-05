using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterON : MonoBehaviour
{
    private Transform obj_Transform;
    

    public CharacterController controller;

    public float speed = 12f;//Скорость движения
    public float speedRotate = 1f;//Скорость поворота
    public float gravity = -9.81f;//Значение ускорения свободного падения.
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;//Вектор скорости V
    bool isGrounded;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        obj_Transform = GetComponent<Transform>();
    }

   
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Проверка, флаг того каксается ли точка земли. Первый агрумент - позиция пустого объекта созданного внутри основного. Второй - радиус в пределах которого будет проходить проверка. Третий - Слой, который будет проверяться.

        if (isGrounded && velocity.y < 0)  //Если объект стоит на земле и вектор скорости по высоте меньше 0, то вектор скорости по высоте(y) становится -2. То есть. Если Чек граунда в области земли, то объект будет падать с гравитацией -2...  Не ясно зачем это. Если это выключить, то объект срывается с обрывов очень резко. Если повысить значение, то будет более плавный отрыв от края, при падении вниз.

        {
            velocity.y = -2f;
        }

        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = /*transform.right * x +*/ transform.forward * z;//Создается вектор направления движения. Базовые вектора направления (вправо и вперед, x=1 и z=1) -не подходят, так как это глобальные координаты. Используются векторы трансформа объекта приведенные к формату "вправо" и "вверх". Далее они умножаются на полученный  от оси результат и при сложении получается вектор направления движения.

            controller.Move(move * speed * Time.deltaTime);// Метод который двигает контроллер по направлению движения, указанного осями и внесенного в переменную move/ Также, вектор умножен на  Дельту Времени и Переменную задающую скорость - так скорость регулируется из оболочки.
        

        //if(Input.GetButtonDown("Jump") && isGrounded) //Прыжок
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);//Метод, который двигает объект по Y.


        if (Input.GetKeyDown(KeyCode.K) )
        {
            controller.Move(Vector3.up);
        }

        
        if(z<0)obj_Transform.Rotate(-Vector3.up * x * speedRotate * Time.deltaTime);//Условная конструкция для правильного движения задним ходом на транспорте.
        else obj_Transform.Rotate(Vector3.up * x * speedRotate * Time.deltaTime);

    }
}
