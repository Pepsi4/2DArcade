using UnityEngine;

public class Area : MonoBehaviour
{

   public static float nowLocationY = 0;    /* Переменная отвечает за Y, в котором 
                                            будет создана новая зона с блоками и бонусами. */
    void Update()
    {
        _CreateNewArea();
    }

    void _CreateNewArea()
    {
        if (GameObject.Find("Point_main").GetComponent<Transform>().position.y >= nowLocationY) // Если Y сопадают
        {
            // --- Создаем префаб Блок --- \\
            Block block = new Block();
            block.SpawnTheBlock(nowLocationY);

            // --- Создаем префаб Бонус --- \\\
            Bonus bonus = new Bonus();
            bonus.SpawnTheBonus(nowLocationY);
        }
    }
}
