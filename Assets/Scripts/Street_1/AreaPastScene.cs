using UnityEngine;
using System.Collections;

public class AreaPastScene : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "MainHero")
        {
            Info.MainHeroPosition = "right";
            Application.LoadLevel("Street_0");
        }
    }
}
