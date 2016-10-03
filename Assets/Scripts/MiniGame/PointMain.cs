using UnityEngine;
using System.Collections;

public class PointMain : MonoBehaviour
{
    public GameObject pointMain; // Главный объект
    GameObject MoveTo; // Точка, к которой движется поинтМейн; Также, ПоинтМейн может менять свою цель на другие префабы МувТу
    public int number = 1; //Номер МувТу, к которому в данный момент надо идти поинтМейн'у
    //public static bool isInvul = false;     //Явяляется ли этот объект неуязвимым
    //public static float invulTime = 0.5f;    //Длительность неуязвимости 
   public float speed = 0.006f; // скорость поинтМейна
   


    void Update()
    {
        MoveTo = GameObject.Find("MOVETO" + " (" + number + ")");       //Для нескольких точек 'MOVETO'


        if (Input.GetKey(KeyCode.A) && pointMain.transform.position.x >= -0.25f) //Если поинтМейн не ушел слишком далеко влево (на 0.15 ед. относительно нуля)
        {
            pointMain.transform.position = Vector3.MoveTowards(pointMain.transform.position, new Vector2(pointMain.transform.position.x - 2, pointMain.transform.position.y), speed);
            MoveTo.transform.position = new Vector2(pointMain.transform.position.x, MoveTo.transform.position.y);   //Двигаем МувТу влево относительно ПоинтМейн
        }
        else if (Input.GetKey(KeyCode.D) && pointMain.transform.position.x <= 0.25f)
        {
            pointMain.transform.position = Vector3.MoveTowards(pointMain.transform.position, new Vector2(pointMain.transform.position.x + 2, pointMain.transform.position.y), speed);
            MoveTo.transform.position = new Vector2(pointMain.transform.position.x, MoveTo.transform.position.y); //Двигаем МувТу вправо относительно ПоинтМейн
        }


        pointMain.transform.position = Vector3.MoveTowards(pointMain.transform.position, new Vector2(MoveTo.transform.position.x, MoveTo.transform.position.y), speed);


        MoveTo.transform.position = new Vector2(MoveTo.transform.position.x, MoveTo.transform.position.y + 10);  // двигаем вверк МувТу
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == MoveTo)
        {
            number++;
        }
    }
}
