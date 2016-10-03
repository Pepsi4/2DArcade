using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Point_main")      //Если врезается в бонус Point_main
        {
            GLOBAL.points++;    //Добавляем очки

            //Меняем значения на таблице UI
            GameObject.Find("Canvas/Points (1)").GetComponent<Text>().text = GLOBAL.points.ToString();
            Destroy(this.gameObject);   //Уничтожаем бонус.
        }
    }


    int trys = 0;

    /// <summary>
    /// Буловое выражение, которое показывает, спавнятся ли сейчас бонусы
    /// </summary>
    public static bool isSpawning = true;


    public void SpawnTheBonus(float nowLocationY)
    {
        if (isSpawning == true)
        {
            trys++; //Добавляем к счетчику попытку

            if (trys == 3 || Random.Range(0, 2) == 0) //Проверяем попытки (33.3%) // На четвертый раз срабатывает с вероятностью 100%
            {
                trys = 0; // Обнуляем попытки

                GameObject bonusPrefab;
                GameObject Bonus;

                Bonus = GameObject.Find("Bonus");
                bonusPrefab = Instantiate(Bonus);               //Префаб Бонуса

                float rndLocationY = Random.Range(5, 7);        //4,5,6 
                rndLocationY /= 20;                             // рнд/20 ед. между блоком и бонусом

                float rndLocationX = Random.Range(0, 2);        //0,1 // Отвечает за позицию по ИКСУ
                float nowLocationX;
                if (rndLocationX == 0)
                {
                    nowLocationX = 0.15f;
                    Debug.Log(rndLocationX);
                }
                else
                {
                    nowLocationX = -0.15f;
                    Debug.Log(rndLocationX);
                }

                bonusPrefab.transform.position = new Vector2(nowLocationX, nowLocationY + rndLocationY); //Задаем позицию Бонуса
            }
        }
    }
}

