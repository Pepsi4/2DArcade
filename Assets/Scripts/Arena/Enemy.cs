using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

   public static int MakeDmg()
    {
        int dmg = Random.Range(HeroController.lvl, HeroController.lvl + 5);
        return dmg;
    }
}
