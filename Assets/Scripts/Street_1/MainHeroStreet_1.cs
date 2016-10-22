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
        IsAfterTheGame();
    }


    void Update()
    {
        Debug.Log(MainHero.IsCanTalk);
        Debug.Log(ArenaInfo.AfterGame == (int)StatusAfterGame.won);
        Debug.Log(ArenaInfo.AfterGame);

        IsTheOldManIsNear();
        // to enabled go to the next dialog
        if (MainHero.IsPressedF())
        {
            IsAfterTheGame();
        }
    }


    void IsAfterTheGame()
    {
        // for the first 
        if (ArenaInfo.AfterGame == (int)StatusAfterGame.won && !MainHero.IsCanTalk)
        {
            DialogInterface.ShowTheDialogWindowAfterGame(true, true);
        }
    }

    //Checking if the OldMan is near
    void IsTheOldManIsNear()
    {
        if (MainHero.IsPressedF() && mainHero.IsNear("OldMan") && MainHero.IsCanTalk)
        {
            TheOldManIsNear();
        }
    }




    void TheOldManIsNear()
    {
        DialogInterface.ShowTheDialogWindow(true, "OldManDialogText", true);
    }
}
