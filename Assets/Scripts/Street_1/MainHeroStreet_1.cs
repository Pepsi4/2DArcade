using UnityEngine;
using System.Collections;

public class MainHeroStreet_1 : MonoBehaviour
{
    #region Fileds

    private MainHero mainHero;
    private DialogInterface dialogInterface;

    #endregion
    // Use this for initialization
    void Start()
    {
        //for the future using classes
        mainHero = GameObject.Find("MainHero").AddComponent<MainHero>();

        //won/lost the last game
        if (ArenaInfo.IsWon == true)
        {
            DialogInterface.ShowTheDialogWindow(false, "OldManDialogText");
        }
    }





    void Update()
    {
        IsTheOldManIsNear();


    }

    //Check if the OldMan is near
    void IsTheOldManIsNear()
    {
        if (MainHero.IsPressedF())
        {
            if (mainHero.IsNear("OldMan"))
            {
                TheOldManIsNear();
            }
        }
    }

    void TheOldManIsNear()
    {
        DialogInterface.ShowTheDialogWindow(true, "OldManDialogText", true);
    }
}
