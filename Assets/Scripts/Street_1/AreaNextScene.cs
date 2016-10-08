using UnityEngine;
using System.Collections;

public class AreaNextScene : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "MainHero")
        {
            Application.LoadLevel("first");
        }
    }
}
