using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private static Sprite[] healthBar = new Sprite[] {
            Resources.Load<Sprite>("Sprites/Arena/HP/Health00"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health10"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health20"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health30"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health40"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health50"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health60"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health70"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health80"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health90"),
            Resources.Load<Sprite>("Sprites/Arena/HP/Health100")
    };

    void Start()
    {
    }

    public static void Test()
    {

    }

    public static void UpdateEnemyHealthBar(int enemyHealth, int maxEnemyHealth)
    {
        for (int counter = 0; counter < 11; counter++)
        {
            if (enemyHealth <= maxEnemyHealth * counter / 10)
            {
                SetEnemyHealthBar(counter);
                return;
            }
        }
    }

    private static void SetEnemyHealthBar(int counter)
    {
        GameObject.Find("Canvas/EnemyUI/EnemyHealthBG").GetComponent<Image>().sprite = healthBar[counter];
    }

    public static void UpdateHeroHealthBar(int heroHealth, int maxHeroHealth)
    {
        for (int counter = 0; counter < 11; counter++)
        {
            if (heroHealth <= maxHeroHealth * counter / 10)
            {
                SetHeroHealthBar(counter);
                return;
            }
        }
    }

    private static void SetHeroHealthBar(int counter)
    {
        GameObject.Find("Canvas/HeroUI/HeroHealthBG").GetComponent<Image>().sprite = healthBar[counter];
    }

}

public enum HelthBar : int
{
    Health100 = 10,
    Health90 = 9,
    Health80 = 8,
    Health70 = 7,
    Health60 = 6,
    Health50 = 5,
    Health40 = 4,
    Health30 = 3,
    Health20 = 2,
    Health10 = 1,
    Health00 = 0
}