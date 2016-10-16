using UnityEngine;
using System.Collections;

public class NextLvlStreet_0 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "MainHero")
        {
            Info.MainHeroPosition = "left";
            Application.LoadLevel("Street_1");
        }
    }
}
