using UnityEngine;
using System.Collections;

public class MainHeroStreet_1 : MonoBehaviour {
    #region Fileds

    private MainHero mainHero;

    #endregion
    // Use this for initialization
    void Start ()
    {
	    mainHero = GameObject.Find("MainHero").AddComponent<MainHero>();
    }
	
	void Update () {
	
	}

    //Check if the OldMan is near
    void IsTheOldManIsNear()
    {
        if (mainHero.IsNear("OldMan"))
        {
            TheOldManIsNear();
        }
    }

    void TheOldManIsNear()
    {
        DialogInterface dialogInterface = new DialogInterface();
        dialogInterface.ShowTheDialogWindow(true, "OldManDialogText");
    }
}
