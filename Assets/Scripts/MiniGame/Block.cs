using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private float delta_time;       //Переменная, которая необходима для реализации таймера (Blink())
    private GameObject gm;          //Главный объект
    private SpriteRenderer sprite;  //Объявляем спрайт для главного объекта
   // static bool isDamaged = false;

    /// <summary>
    /// /// Буловое выражение, отвечает за спавн блоков
    /// </summary>
   public static  bool isSpawning = true;

    void Start()
    {
        gm = GameObject.Find("Point_main");             //nahodim main ob`ekt
        sprite = gm.GetComponent<SpriteRenderer>();     //polychaem dostyp k sprity main ob'ekta
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Point_main")    //Если врезается в блок и объект уязвим
        {
            GLOBAL.lifes--;              // Otnimaem jizni
            if (GLOBAL.lifes <= 0)       //Если у игрока закончились жизни 
            {
                Bonus.isSpawning = false;               //Останваливаем спавн бонусов
                Block.isSpawning = false;               //Останавливаем спавн блоков
                Camera.isGoing = false;                 //Останавливаем движение камеры
                Road.isGoing = false;                   //Останваливаем движение дороги
            }
            GameObject.Find("Canvas/Lifes (1)").GetComponent<Text>().text = GLOBAL.lifes.ToString();
            GetDmg();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Blink(false);
    }

    void Update()
    {
       // Blink(isDamaged);
    }

    void GetDmg()
    {
        if (delta_time > 0)
        {
            delta_time -= Time.deltaTime;   //Otvodim vremya s 0.3 do 0
            Blink(false);                   // Vrubaem(ON) textury
        }
        if (delta_time <= 0) Blink(true);   // Vremya vishlo, virubaem(OFF) texturu
    } 


    void Blink(bool isDamaged)
    {
        if (isDamaged == true)
        {
            delta_time = 0.003f;                  //vremya do sledyeshego margani9
            sprite.enabled = false;
        }
        if (isDamaged == false)
        {
            sprite.enabled = true;
        }
    } 





    public void SpawnTheBlock(float nowLocationY)
    {
        if (isSpawning == true)
        {
            float rndLocation = Random.Range(7, 11); //0.7, 0.8, 0.9
            rndLocation /= 10;
            int rndLocationX = 0;
            float nowLocationX = 0;
            rndLocationX = Random.Range(1, 3);  //1 or 2
            nowLocationY += rndLocation;        // Меняем значение У

            GameObject wall;                    // Инициализация объекта "блок"
            wall = GameObject.Find("Block");

            GameObject wallPrefab;              // Создаем префаб объекта "Блок"
            wallPrefab = Instantiate(wall);

            if (rndLocationX == 1)
            {
                nowLocationX = -0.83f;
            }
            else if (rndLocationX == 2)
            {
                nowLocationX = -1.1f;
            }

            Area.nowLocationY = nowLocationY;      //Передаем значение в класс, отвечающий за Y новой облости

            wallPrefab.GetComponent<Transform>().position = new Vector2(nowLocationX, nowLocationY);  //Задаем месторасположение стены
        }

    }

}
