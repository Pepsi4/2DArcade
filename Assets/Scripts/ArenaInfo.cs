using UnityEngine;
using System.Collections;

static public class ArenaInfo
{
    private static int lvl = 1;
    private static int enemyHealth;
    private static int heroHealth;
    //private static int award;

    
    public static int Lvl
    {
        get { return lvl; }
        set { value = lvl; }
    }

    public static int RandomAward()
    {
        int award = Random.Range(1, 4) * lvl;
        MainHero.Gold += award;

        return award;
    }

    public static int AfterGame { get; set; }

}


public enum StatusAfterGame : int
{
    nothing = 0,
    won = 1,
    lose = 2
}

