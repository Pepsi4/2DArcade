using UnityEngine;
using System.Collections;

public class MainHeroStreet : MonoBehaviour {

    private MainHero mainHero;
    void Start()
    {
        mainHero = GameObject.Find("MainHero").AddComponent<MainHero>();
    }

    void Update()
    {
        mainHero.Update();
    }

    void isBuildingIsNear()
    {
        //GameObject.Find();
    }


}
