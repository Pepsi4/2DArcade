using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Fields

    private static int enemyHealth = 20;
    private static int enemyMaxHealth = 20;
    private static int enemyLvl = MainHero.Level;

    #endregion

    #region Properties

    public static int EnemyHealth
    {
        get { return enemyHealth; }
        set { enemyHealth = value; }
    }

    public static int EnemyMaxHealth
    {
        get { return enemyMaxHealth; }
        set { enemyMaxHealth = value; }
    }

    #endregion

    public static int MakeDmg()
    {
        //the clean dmg 
        int dmg = Random.Range(enemyLvl, enemyLvl + 6);
        //the dmg with including the armor
        dmg = dmg - MainHero.Armor;

        if (dmg <= 0) dmg = 1;

        return dmg;
    }

    void Start()
    {
        UpdateEnemyUiLevel();
    }

    void UpdateEnemyUiLevel()
    {
        //Main hero level always = enemy lvl
        GameObject.Find("Canvas/EnemyUI/TextLvl").GetComponent<Text>().text = "Level: " + MainHero.Level;
    }
}
